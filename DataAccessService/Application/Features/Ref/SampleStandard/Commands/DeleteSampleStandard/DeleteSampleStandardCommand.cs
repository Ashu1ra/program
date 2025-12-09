using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Commands.DeleteSampleStandard;

public record DeleteSampleStandardCommand(long Id)
    : IRequest<Unit>;