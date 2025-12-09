using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Sites.Queries.GetSiteList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Queries.GetSiteList;

public class GetSiteListHandler
    : IRequestHandler<GetSiteListQuery, IReadOnlyList<SiteResponseDto>>
{
    private readonly IReadOnlyRepository<Site> _repo;
    private readonly AclGuard _acl;

    public GetSiteListHandler(IReadOnlyRepository<Site> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<SiteResponseDto>> Handle(
        GetSiteListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "site", null, ct);

        var list = await _repo.GetAllAsync(ct);

        return list.Select(entity =>
            new SiteResponseDto(
                entity.Id,
                entity.LinkProject,
                entity.Name.Value,
                PolygonMapper.ToDto(entity.Area),
                entity.Description,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.OwnerUserId
            )
        ).ToList();
    }
}