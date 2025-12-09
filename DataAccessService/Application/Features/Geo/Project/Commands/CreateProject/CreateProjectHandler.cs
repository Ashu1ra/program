using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Commands.CreateProject;

public class CreateProjectHandler
    : IRequestHandler<CreateProjectCommand, long>
{
    private readonly IRepository<Project> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateProjectHandler(
        IRepository<Project> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateProjectCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "project", null, ct);

        var dto = request.Dto;

        var entity = Project.Create(
            dto.LinkListRegion,
            Name.Create(dto.Name),
            dto.LinkDataSource,
            PointZ.Create(dto.CenterLocation.X, dto.CenterLocation.Y, dto.CenterLocation.Z),
            MultiPolygonMapper.ToDomain(dto.Area),
            _current.UserId
        );


        entity.UpdateDescription(dto.Description);

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}