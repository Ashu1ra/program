using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Commands.UpdateCityModel;

public record UpdateCityModelCommand(long Id, UpdateCityModelDto Dto)
    : IRequest<Unit>;
