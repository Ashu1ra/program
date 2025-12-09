using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Groups.Queries.GetGroupList;

public class GetGroupListHandler
    : IRequestHandler<GetGroupListQuery, IReadOnlyList<GroupListResponseDto>>
{
    private readonly IReadOnlyRepository<GroupList> _repo;
    private readonly AclGuard _acl;

    public GetGroupListHandler(
        IReadOnlyRepository<GroupList> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<GroupListResponseDto>> Handle(GetGroupListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "group_list", null, ct);

        var groups = await _repo.GetAllAsync(ct);

        return groups.Select(g => new GroupListResponseDto(
            g.Id,
            g.Name,
            g.Description
        )).ToList();
    }
}