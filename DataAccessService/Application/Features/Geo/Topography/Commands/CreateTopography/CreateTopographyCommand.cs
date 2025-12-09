using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Commands.CreateTopography;

public record CreateTopographyCommand(CreateTopographyDto Dto)
    : IRequest<long>;