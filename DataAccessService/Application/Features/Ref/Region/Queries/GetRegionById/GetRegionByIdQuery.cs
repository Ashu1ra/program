using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Queries.GetRegionById;

public record GetRegionByIdQuery(long Id)
    : IRequest<ListRegionResponseDto>;