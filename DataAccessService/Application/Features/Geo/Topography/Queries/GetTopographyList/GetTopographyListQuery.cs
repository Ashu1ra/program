using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Queries.GetTopographyList;

public record GetTopographyListQuery()
    : IRequest<IReadOnlyList<TopographyResponseDto>>;