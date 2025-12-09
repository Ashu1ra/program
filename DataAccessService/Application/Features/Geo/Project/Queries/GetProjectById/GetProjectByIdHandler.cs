using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Projects.Queries.GetProjectById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Queries.GetProjectById;

public class GetProjectByIdHandler
    : IRequestHandler<GetProjectByIdQuery, ProjectResponseDto>
{
    private readonly IReadOnlyRepository<Project> _repo;
    private readonly AclGuard _acl;

    public GetProjectByIdHandler(IReadOnlyRepository<Project> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<ProjectResponseDto> Handle(GetProjectByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "project", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Project not found");

        return new ProjectResponseDto(
            entity.Id,
            entity.LinkListRegion,
            entity.Name.Value,
            entity.LinkDataSource,
            new PointZDto(entity.CenterLocation.X, entity.CenterLocation.Y, entity.CenterLocation.Z),
            MultiPolygonMapper.ToDto(entity.Area),
            entity.DateStart,
            entity.Description,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}