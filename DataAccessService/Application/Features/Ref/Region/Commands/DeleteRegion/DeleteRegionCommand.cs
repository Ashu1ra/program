using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Commands.DeleteRegion;

public record DeleteRegionCommand(long Id)
    : IRequest<Unit>;