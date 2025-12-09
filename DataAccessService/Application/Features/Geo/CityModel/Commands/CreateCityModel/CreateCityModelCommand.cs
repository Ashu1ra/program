using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Commands.CreateCityModel;

public record CreateCityModelCommand(CreateCityModelDto Dto)
    : IRequest<long>;