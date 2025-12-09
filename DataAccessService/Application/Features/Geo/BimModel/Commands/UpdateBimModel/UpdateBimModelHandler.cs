using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.Features.Geo.BimModels.Commands.UpdateBimModel;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Commands.UpdateBimModel;

public class UpdateBimModelHandler
    : IRequestHandler<UpdateBimModelCommand, Unit>
{
    private readonly IRepository<BimModel> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateBimModelHandler(IRepository<BimModel> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateBimModelCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "bim_model", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("BimModel not found");

        var dto = request.Dto;

        if (dto.Format is not null)
            entity.UpdateFormat(ModelFormatMapper.ToDomain(dto.Format));

        if (dto.Area is not null)
            entity.UpdateArea(MultiPolygonMapper.ToDomain(dto.Area));

        if (dto.FileData is not null)
            entity.ReplaceFile(dto.FileData);

        if (dto.Metadata is not null)
            entity.UpdateMetadata(dto.Metadata);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}