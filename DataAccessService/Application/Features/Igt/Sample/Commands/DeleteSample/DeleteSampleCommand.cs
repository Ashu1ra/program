using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Commands.DeleteSample;

public record DeleteSampleCommand(long Id)
    : IRequest<Unit>;