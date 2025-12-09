using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Queries.GetRoleById;

public class GetRoleByIdHandler
    : IRequestHandler<GetRoleByIdQuery, RoleListResponseDto>
{
    private readonly IReadOnlyRepository<RoleList> _repo;
    private readonly AclGuard _acl;

    public GetRoleByIdHandler(
        IReadOnlyRepository<RoleList> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<RoleListResponseDto> Handle(GetRoleByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "role_list", request.Id, ct);

        var role = await _repo.GetByIdAsync(request.Id, ct);
        if (role == null)
            throw new NotFoundException($"Role {request.Id} not found");

        return new RoleListResponseDto(
            role.Id,
            role.Name,
            role.Description
        );
    }
}