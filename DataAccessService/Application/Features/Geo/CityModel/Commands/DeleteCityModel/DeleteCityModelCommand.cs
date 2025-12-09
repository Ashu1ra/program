using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Commands.DeleteCityModel;

public record DeleteCityModelCommand(long Id)
    : IRequest<Unit>;