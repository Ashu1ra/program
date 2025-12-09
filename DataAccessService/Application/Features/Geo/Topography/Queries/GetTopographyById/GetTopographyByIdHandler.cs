using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Topographys.Queries.GetTopographyById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Queries.GetTopographyById;

public class GetTopographyByIdHandler
    : IRequestHandler<GetTopographyByIdQuery, TopographyResponseDto>
{
    private readonly IReadOnlyRepository<Topography> _repo;
    private readonly AclGuard _acl;

    public GetTopographyByIdHandler(IReadOnlyRepository<Topography> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<TopographyResponseDto> Handle(GetTopographyByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "topography", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Topography not found");

        return new TopographyResponseDto(
            entity.Id,
            entity.LinkSite,
            entity.LinkDataSource,
            MultiPolygonMapper.ToDto(entity.Area),
            entity.Description,
            entity.Metadata,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}