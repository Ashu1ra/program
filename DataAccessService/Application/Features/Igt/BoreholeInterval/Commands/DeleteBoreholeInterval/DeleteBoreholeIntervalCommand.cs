using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Commands.DeleteBoreholeInterval;

public record DeleteBoreholeIntervalCommand(long Id)
    : IRequest<Unit>;