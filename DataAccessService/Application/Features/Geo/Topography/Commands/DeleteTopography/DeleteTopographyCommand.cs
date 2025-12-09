using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Commands.DeleteTopography;

public record DeleteTopographyCommand(long Id)
    : IRequest<Unit>;