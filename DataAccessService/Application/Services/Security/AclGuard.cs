using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Exceptions;

namespace DataAccessService.Application.Services.Security;

public class AclGuard
{
    private readonly IAccessControlService _acl;

    public AclGuard(IAccessControlService acl)
    {
        _acl = acl;
    }

    public async Task RequireReadAsync(string schema, string table, long? objectId = null, CancellationToken ct = default)
    {
        if (!await _acl.CanReadAsync(schema, table, objectId, ct))
            throw new ForbiddenException("You do not have permission to read this resource.");
    }

    public async Task RequireWriteAsync(string schema, string table, long? objectId = null, CancellationToken ct = default)
    {
        if (!await _acl.CanWriteAsync(schema, table, objectId, ct))
            throw new ForbiddenException("You do not have permission to modify this resource.");
    }

    public async Task RequireDeleteAsync(string schema, string table, long? objectId = null, CancellationToken ct = default)
    {
        if (!await _acl.CanDeleteAsync(schema, table, objectId, ct))
            throw new ForbiddenException("You do not have permission to delete this resource.");
    }
}