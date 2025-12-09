using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Commands.UpdateRole;

public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Unit>
{
    private readonly IRepository<RoleList> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateRoleHandler(
        IRepository<RoleList> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "role_list", request.Id, ct);

        var role = await _repo.GetByIdAsync(request.Id, ct);
        if (role == null)
            throw new NotFoundException("Role not found");

        var dto = request.Dto;

        role.Rename(dto.Name);
        role.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}