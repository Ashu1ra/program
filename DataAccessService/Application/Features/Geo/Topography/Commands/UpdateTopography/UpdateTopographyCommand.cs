using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Commands.UpdateTopography;

public record UpdateTopographyCommand(long Id, UpdateTopographyDto Dto)
    : IRequest<Unit>;