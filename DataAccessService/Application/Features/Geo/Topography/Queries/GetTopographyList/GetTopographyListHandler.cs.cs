using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Topographys.Queries.GetTopographyList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Queries.GetTopographyList;

public class GetTopographyListHandler
    : IRequestHandler<GetTopographyListQuery, IReadOnlyList<TopographyResponseDto>>
{
    private readonly IReadOnlyRepository<Topography> _repo;
    private readonly AclGuard _acl;

    public GetTopographyListHandler(IReadOnlyRepository<Topography> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<TopographyResponseDto>> Handle(GetTopographyListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "topography", null, ct);

        var list = await _repo.GetAllAsync(ct);

        return list.Select(e =>
            new TopographyResponseDto(
                e.Id,
                e.LinkSite,
                e.LinkDataSource,
                MultiPolygonMapper.ToDto(e.Area),
                e.Description,
                e.Metadata,
                e.CreatedAt,
                e.UpdatedAt,
                e.OwnerUserId
            )
        ).ToList();
    }
}