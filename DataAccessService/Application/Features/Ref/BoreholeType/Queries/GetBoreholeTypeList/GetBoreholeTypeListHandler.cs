using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Queries.GetBoreholeTypeList;

public class GetBoreholeTypeListHandler
    : IRequestHandler<GetBoreholeTypeListQuery, IReadOnlyList<ListBoreholeTypeResponseDto>>
{
    private readonly IReadOnlyRepository<ListBoreholeType> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeTypeListHandler(
        IReadOnlyRepository<ListBoreholeType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListBoreholeTypeResponseDto>> Handle(
        GetBoreholeTypeListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_borehole_type", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(entity =>
            new ListBoreholeTypeResponseDto(
                entity.Id,
                entity.Mnemonic.Value,
                entity.Name.Value,
                entity.Description
            )
        ).ToList();
    }
}