using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Queries.GetCityModelById;

public record GetCityModelByIdQuery(long Id)
    : IRequest<CityModelResponseDto>;
