using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Commands.CreateRegion;

public record CreateRegionCommand(CreateListRegionDto Dto)
    : IRequest<long>;