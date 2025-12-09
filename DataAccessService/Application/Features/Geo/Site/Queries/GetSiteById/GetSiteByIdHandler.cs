using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Sites.Queries.GetSiteById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Queries.GetSiteById;

public class GetSiteByIdHandler
    : IRequestHandler<GetSiteByIdQuery, SiteResponseDto>
{
    private readonly IReadOnlyRepository<Site> _repo;
    private readonly AclGuard _acl;

    public GetSiteByIdHandler(IReadOnlyRepository<Site> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<SiteResponseDto> Handle(GetSiteByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "site", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Site not found");

        return new SiteResponseDto(
            entity.Id,
            entity.LinkProject,
            entity.Name.Value,
            PolygonMapper.ToDto(entity.Area),
            entity.Description,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}