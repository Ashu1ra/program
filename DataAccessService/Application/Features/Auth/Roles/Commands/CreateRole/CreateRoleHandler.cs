using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Commands.CreateRole;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, long>
{
    private readonly IRepository<RoleList> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateRoleHandler(
        IRepository<RoleList> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateRoleCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("auth", "role_list", null, ct); // только admin

        var dto = request.Dto;

        var role = RoleList.Create(dto.Name, dto.Description);

        await _repo.AddAsync(role, ct);
        await _uow.SaveChangesAsync(ct);

        return role.Id;
    }
}