using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.CityModels.Queries.GetCityModelList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Queries.GetCityModelList;

public class GetCityModelListHandler
    : IRequestHandler<GetCityModelListQuery, IReadOnlyList<CityModelResponseDto>>
{
    private readonly IReadOnlyRepository<CityModel> _repo;
    private readonly AclGuard _acl;

    public GetCityModelListHandler(IReadOnlyRepository<CityModel> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<CityModelResponseDto>> Handle(GetCityModelListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "city_model", null, ct);

        var list = await _repo.GetAllAsync(ct);

        return list.Select(e =>
            new CityModelResponseDto(
                e.Id,
                e.LinkSite,
                e.Format.Value,
                MultiPolygonMapper.ToDto(e.Area),
                e.Metadata,
                e.CreatedAt,
                e.UpdatedAt,
                e.OwnerUserId
            )
        ).ToList();
    }
}
