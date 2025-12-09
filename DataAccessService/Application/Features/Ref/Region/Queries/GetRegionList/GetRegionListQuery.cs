using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Queries.GetRegionList;

public record GetRegionListQuery()
    : IRequest<IReadOnlyList<ListRegionResponseDto>>;