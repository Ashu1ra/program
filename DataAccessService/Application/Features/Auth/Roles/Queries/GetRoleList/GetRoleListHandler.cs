using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Queries.GetRoleList;

public class GetRoleListHandler
    : IRequestHandler<GetRoleListQuery, IReadOnlyList<RoleListResponseDto>>
{
    private readonly IReadOnlyRepository<RoleList> _repo;
    private readonly AclGuard _acl;

    public GetRoleListHandler(
        IReadOnlyRepository<RoleList> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<RoleListResponseDto>> Handle(
        GetRoleListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "role_list", null, ct);

        var roles = await _repo.GetAllAsync(ct);

        return roles.Select(r => new RoleListResponseDto(
            r.Id,
            r.Name,
            r.Description
        )).ToList();
    }
}