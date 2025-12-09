using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Commands.UpdateSite;

public record UpdateSiteCommand(long Id, UpdateSiteDto Dto)
    : IRequest<Unit>;