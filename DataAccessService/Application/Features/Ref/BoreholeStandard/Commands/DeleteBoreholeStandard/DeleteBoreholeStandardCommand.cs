using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Commands.DeleteBoreholeStandard;

public record DeleteBoreholeStandardCommand(long Id)
    : IRequest<Unit>;