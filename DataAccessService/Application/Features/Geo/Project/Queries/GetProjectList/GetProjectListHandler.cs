using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Projects.Queries.GetProjectList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Queries.GetProjectList;

public class GetProjectListHandler
    : IRequestHandler<GetProjectListQuery, IReadOnlyList<ProjectResponseDto>>
{
    private readonly IReadOnlyRepository<Project> _repo;
    private readonly AclGuard _acl;

    public GetProjectListHandler(IReadOnlyRepository<Project> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ProjectResponseDto>> Handle(GetProjectListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "project", null, ct);

        var list = await _repo.GetAllAsync(ct);

        return list.Select(entity =>
            new ProjectResponseDto(
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
            )
        ).ToList();
    }
}