using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Queries.GetCityModelList;

public record GetCityModelListQuery()
    : IRequest<IReadOnlyList<CityModelResponseDto>>;
