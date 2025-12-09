using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.Features.Geo.CityModels.Commands.UpdateCityModel;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Commands.UpdateCityModel;

public class UpdateCityModelHandler
    : IRequestHandler<UpdateCityModelCommand, Unit>
{
    private readonly IRepository<CityModel> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateCityModelHandler(IRepository<CityModel> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateCityModelCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "city_model", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("CityModel not found");

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