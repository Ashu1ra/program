using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.Application.Services.Acl;

public class AccessControlService : IAccessControlService
{
    private readonly ICurrentUserService _current;
    private readonly IReadOnlyRepository<AccessControl> _aclRepo;
    private readonly IUserGroupRepository _userGroupRepo;
    private readonly IUserRoleRepository _userRoleRepo;

    public AccessControlService(
        ICurrentUserService current,
        IReadOnlyRepository<AccessControl> aclRepo,
        IUserGroupRepository userGroupRepo,
        IUserRoleRepository userRoleRepo)
    {
        _current = current;
        _aclRepo = aclRepo;
        _userGroupRepo = userGroupRepo;
        _userRoleRepo = userRoleRepo;
    }

    public Task<bool> CanReadAsync(string schema, string table, long? objectId = null, CancellationToken cancellationToken = default)
        => CheckPermissionAsync(schema, table, objectId, a => a.CanRead, cancellationToken);

    public Task<bool> CanWriteAsync(string schema, string table, long? objectId = null, CancellationToken cancellationToken = default)
        => CheckPermissionAsync(schema, table, objectId, a => a.CanWrite, cancellationToken);

    public Task<bool> CanDeleteAsync(string schema, string table, long? objectId = null, CancellationToken cancellationToken = default)
        => CheckPermissionAsync(schema, table, objectId, a => a.CanDelete, cancellationToken);

    private async Task<bool> CheckPermissionAsync(
        string schema,
        string table,
        long? objectId,
        Func<AccessControl, bool> permissionSelector,
        CancellationToken cancellationToken)
    {
        if (!_current.IsAuthenticated)
            return false;

        var userId = _current.UserId;

        var aclEntries = await _aclRepo.GetAllAsync(cancellationToken);

        var forEntity = aclEntries.Where(a =>
            a.EntitySchema.Equals(schema, StringComparison.OrdinalIgnoreCase) &&
            a.EntityName.Equals(table, StringComparison.OrdinalIgnoreCase));

        var applicable = forEntity.Where(a =>
            a.ObjectId == null || a.ObjectId == objectId);

        if (applicable.Any(a => a.LinkUserAccount == userId && permissionSelector(a)))
            return true;

        var groupIds = await _userGroupRepo.GetGroupIdsByUserAsync(userId, cancellationToken);
        if (applicable.Any(a => a.LinkGroupList != null &&
                                groupIds.Contains(a.LinkGroupList.Value) &&
                                permissionSelector(a)))
            return true;

        var roleIds = await _userRoleRepo.GetRoleIdsByUserAsync(userId, cancellationToken);
        if (applicable.Any(a => a.LinkRoleList != null &&
                                roleIds.Contains(a.LinkRoleList.Value) &&
                                permissionSelector(a)))
            return true;

        if (applicable.Any(a => a.ObjectId == null && permissionSelector(a)))
            return true;

        return false;
    }
}
