using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Acl.Commands.UpdateAclRule;

public class UpdateAclRuleHandler : IRequestHandler<UpdateAclRuleCommand, Unit>
{
    private readonly IRepository<AccessControl> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateAclRuleHandler(
        IRepository<AccessControl> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateAclRuleCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "access_control", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ACL Rule not found");

        var dto = request.Dto;

        entity.UpdatePermissions(
            dto.CanRead ?? entity.CanRead,
            dto.CanWrite ?? entity.CanWrite,
            dto.CanDelete ?? entity.CanDelete
        );

        entity.UpdateMetadata(dto.Metadata);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}