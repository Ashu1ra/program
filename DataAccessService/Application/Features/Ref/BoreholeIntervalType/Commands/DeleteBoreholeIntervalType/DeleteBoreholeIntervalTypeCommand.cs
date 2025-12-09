using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Commands.DeleteBoreholeIntervalType;

public record DeleteBoreholeIntervalTypeCommand(long Id)
    : IRequest<Unit>;