using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Commands.DeleteRole;

public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Unit>
{
    private readonly IRepository<RoleList> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteRoleHandler(
        IRepository<RoleList> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("auth", "role_list", request.Id, ct);

        var role = await _repo.GetByIdAsync(request.Id, ct);
        if (role == null)
            throw new NotFoundException("Role not found");

        _repo.Remove(role);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}