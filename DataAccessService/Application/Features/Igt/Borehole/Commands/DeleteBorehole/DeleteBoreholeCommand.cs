using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Commands.DeleteBorehole;

public record DeleteBoreholeCommand(long Id) : IRequest<Unit>;