using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Commands.DeleteSite;

public record DeleteSiteCommand(long Id)
    : IRequest<Unit>;