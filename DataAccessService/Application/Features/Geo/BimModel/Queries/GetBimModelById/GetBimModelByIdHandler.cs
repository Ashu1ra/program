using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.BimModels.Queries.GetBimModelById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Queries.GetBimModelById;

public class GetBimModelByIdHandler
    : IRequestHandler<GetBimModelByIdQuery, BimModelResponseDto>
{
    private readonly IReadOnlyRepository<BimModel> _repo;
    private readonly AclGuard _acl;

    public GetBimModelByIdHandler(IReadOnlyRepository<BimModel> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<BimModelResponseDto> Handle(GetBimModelByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "bim_model", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("BimModel not found");

        return new BimModelResponseDto(
            entity.Id,
            entity.LinkSite,
            entity.Format.Value,
            MultiPolygonMapper.ToDto(entity.Area),
            entity.Metadata,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}