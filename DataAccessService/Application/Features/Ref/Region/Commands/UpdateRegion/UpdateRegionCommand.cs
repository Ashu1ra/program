using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Commands.UpdateRegion;

public record UpdateRegionCommand(long Id, UpdateListRegionDto Dto)
    : IRequest<Unit>;