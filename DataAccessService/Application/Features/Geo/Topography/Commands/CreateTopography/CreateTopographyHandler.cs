using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.Topographys.Commands.CreateTopography;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Commands.CreateTopography;

public class CreateTopographyHandler : IRequestHandler<CreateTopographyCommand, long>
{
    private readonly IRepository<Topography> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateTopographyHandler(
        IRepository<Topography> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateTopographyCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "topography", null, ct);

        var dto = request.Dto;

        var entity = Topography.Create(
            siteId: dto.LinkSite,
            dataSourceId: dto.LinkDataSource,
            area: MultiPolygonMapper.ToDomain(dto.Area),
            raster: dto.RasterFile,
            metadata: dto.Metadata ?? "{}",
            owner: _current.UserId
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}
