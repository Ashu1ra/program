using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Commands.CreateSite;

public record CreateSiteCommand(CreateSiteDto Dto)
    : IRequest<long>;