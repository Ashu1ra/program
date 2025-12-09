using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.Features.Geo.Topographys.Commands.UpdateTopography;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Commands.UpdateTopography;

public class UpdateTopographyHandler : IRequestHandler<UpdateTopographyCommand, Unit>
{
    private readonly IRepository<Topography> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateTopographyHandler(IRepository<Topography> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateTopographyCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "topography", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Topography not found");

        var dto = request.Dto;

        entity.UpdateArea(MultiPolygonMapper.ToDomain(dto.Area));

        if (dto.RasterFile is not null)
            entity.ReplaceRaster(dto.RasterFile);

        if (dto.Metadata is not null)
            entity.UpdateMetadata(dto.Metadata);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}