using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Commands.CreateAclRule;

public class CreateAclRuleHandler : IRequestHandler<CreateAclRuleCommand, long>
{
    private readonly IRepository<AccessControl> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public CreateAclRuleHandler(
        IRepository<AccessControl> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<long> Handle(CreateAclRuleCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "access_control", null, ct);

        var dto = request.Dto;

        var aclEntry = AccessControl.Create(
            dto.EntitySchema,
            dto.EntityName,
            dto.ObjectId,
            dto.UserId,
            dto.GroupId,
            dto.RoleId,
            dto.CanRead,
            dto.CanWrite,
            dto.CanDelete,
            dto.Metadata
        );

        await _repo.AddAsync(aclEntry, ct);
        await _uow.SaveChangesAsync(ct);

        return aclEntry.Id;
    }
}