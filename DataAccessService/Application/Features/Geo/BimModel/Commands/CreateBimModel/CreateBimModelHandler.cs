using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.BimModels.Commands.CreateBimModel;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Commands.CreateBimModel;

public class CreateBimModelHandler
    : IRequestHandler<CreateBimModelCommand, long>
{
    private readonly IRepository<BimModel> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateBimModelHandler(
        IRepository<BimModel> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateBimModelCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("geo", "bim_model", null, ct);

        var dto = request.Dto;

        var entity = BimModel.Create(
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