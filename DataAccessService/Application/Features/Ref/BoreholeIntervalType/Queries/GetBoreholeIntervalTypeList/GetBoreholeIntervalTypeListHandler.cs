using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Queries.GetBoreholeIntervalTypeList;

public class GetBoreholeIntervalTypeListHandler
    : IRequestHandler<GetBoreholeIntervalTypeListQuery, IReadOnlyList<ListBoreholeIntervalTypeResponseDto>>
{
    private readonly IReadOnlyRepository<ListBoreholeIntervalType> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeIntervalTypeListHandler(
        IReadOnlyRepository<ListBoreholeIntervalType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListBoreholeIntervalTypeResponseDto>> Handle(
        GetBoreholeIntervalTypeListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_borehole_interval_type", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(entity =>
            new ListBoreholeIntervalTypeResponseDto(
                entity.Id,
                entity.Mnemonic.Value,
                entity.Name.Value,
                entity.Metadata,
                entity.Description
            )
        ).ToList();
    }
}