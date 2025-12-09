using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Queries.GetTopographyById;

public record GetTopographyByIdQuery(long Id)
    : IRequest<TopographyResponseDto>;
