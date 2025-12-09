using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Commands.DeleteBoreholeType;

public record DeleteBoreholeTypeCommand(long Id)
    : IRequest<Unit>;