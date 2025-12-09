using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Sites.Commands.UpdateSite;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Domain.ValueObjects;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Sites.Commands.UpdateSite;

public class UpdateSiteHandler : IRequestHandler<UpdateSiteCommand, Unit>
{
    private readonly IRepository<Site> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateSiteHandler(
        IRepository<Site> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateSiteCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "site", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Site not found");

        var dto = request.Dto;

        entity.UpdateName(Name.Create(dto.Name));
        entity.UpdateArea(PolygonMapper.ToDomain(dto.Area));

        if (dto.Description is not null)
            entity.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
