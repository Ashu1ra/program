using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Queries.GetRegionList;

public class GetRegionListHandler
    : IRequestHandler<GetRegionListQuery, IReadOnlyList<ListRegionResponseDto>>
{
    private readonly IReadOnlyRepository<ListRegion> _repo;
    private readonly AclGuard _acl;

    public GetRegionListHandler(
        IReadOnlyRepository<ListRegion> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListRegionResponseDto>> Handle(
        GetRegionListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_region", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items
            .Select(e => new ListRegionResponseDto(
                e.Id,
                e.Mnemonic.Value,
                e.Code.Value,
                e.Name.Value
            ))
            .ToList();
    }
}