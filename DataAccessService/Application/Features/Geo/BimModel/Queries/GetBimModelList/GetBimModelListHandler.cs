using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Geo;
using DataAccessService.Application.Features.Geo.BimModels.Queries.GetBimModelList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Common;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Queries.GetBimModelList;

public class GetBimModelListHandler
    : IRequestHandler<GetBimModelListQuery, IReadOnlyList<BimModelResponseDto>>
{
    private readonly IReadOnlyRepository<BimModel> _repo;
    private readonly AclGuard _acl;

    public GetBimModelListHandler(IReadOnlyRepository<BimModel> repo, AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<BimModelResponseDto>> Handle(GetBimModelListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("geo", "bim_model", null, ct);

        var list = await _repo.GetAllAsync(ct);

        return list.Select(e =>
            new BimModelResponseDto(
                e.Id,
                e.LinkSite,
                e.Format.Value,
                MultiPolygonMapper.ToDto(e.Area),
                e.Metadata,
                e.CreatedAt,
                e.UpdatedAt,
                e.OwnerUserId
            )
        ).ToList();
    }
}