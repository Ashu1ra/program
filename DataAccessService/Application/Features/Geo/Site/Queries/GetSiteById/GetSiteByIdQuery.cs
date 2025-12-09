using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Queries.GetSiteById;

public record GetSiteByIdQuery(long Id)
    : IRequest<SiteResponseDto>;