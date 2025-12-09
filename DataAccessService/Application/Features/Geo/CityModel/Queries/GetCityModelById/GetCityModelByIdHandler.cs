using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.CityModels.Queries.GetCityModelById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Queries.GetCityModelById;

public class GetCityModelByIdHandler
    : IRequestHandler<GetCityModelByIdQuery, CityModelResponseDto>
{
    private readonly IReadOnlyRepository<CityModel> _repo;
    private readonly AclGuard _acl;

    public GetCityModelByIdHandler(IReadOnlyRepository<CityModel> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<CityModelResponseDto> Handle(GetCityModelByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "city_model", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("CityModel not found");

        return new CityModelResponseDto(
            entity.Id,
            entity.LinkSite,
            entity.Format.Value,
            MultiPolygonMapper.ToDto(entity.Area),
            entity.Metadata,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}