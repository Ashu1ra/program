using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.CityModels.Commands.CreateCityModel;

public class CreateCityModelHandler : IRequestHandler<CreateCityModelCommand, long>
{
    private readonly IRepository<CityModel> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateCityModelHandler(
        IRepository<CityModel> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateCityModelCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "city_model", null, ct);

        var dto = request.Dto;

        var entity = CityModel.Create(
            siteId: dto.LinkSite,
            format: ModelFormatMapper.ToDomain(dto.Format),
            area: MultiPolygonMapper.ToDomain(dto.Area),
            fileData: dto.FileData,
            metadata: dto.Metadata ?? "{}"
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}