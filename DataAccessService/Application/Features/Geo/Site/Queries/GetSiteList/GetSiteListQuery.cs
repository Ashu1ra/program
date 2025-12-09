using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Queries.GetSiteList;

public record GetSiteListQuery()
    : IRequest<IReadOnlyList<SiteResponseDto>>;