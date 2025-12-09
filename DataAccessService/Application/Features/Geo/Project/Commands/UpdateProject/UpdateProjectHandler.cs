using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Projects.Commands.UpdateProject;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Commands.UpdateProject;

public class UpdateProjectHandler
    : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IRepository<Project> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateProjectHandler(IRepository<Project> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "project", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Project not found");

        var dto = request.Dto;

        entity.UpdateName(Name.Create(dto.Name));
        entity.UpdateCenter(PointZ.Create(dto.CenterLocation.X, dto.CenterLocation.Y, dto.CenterLocation.Z));
        entity.UpdateArea(MultiPolygonMapper.ToDomain(dto.Area));
        entity.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
