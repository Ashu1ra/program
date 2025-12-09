using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Queries.GetBoreholeStandardList;

public class GetBoreholeStandardListHandler
    : IRequestHandler<GetBoreholeStandardListQuery, IReadOnlyList<ListBoreholeStandardResponseDto>>
{
    private readonly IReadOnlyRepository<ListBoreholeStandard> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeStandardListHandler(
        IReadOnlyRepository<ListBoreholeStandard> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListBoreholeStandardResponseDto>> Handle(
        GetBoreholeStandardListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_borehole_standard", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(entity =>
            new ListBoreholeStandardResponseDto(
                entity.Id,
                entity.Mnemonic.Value,
                entity.Name.Value,
                entity.Description
            )
        ).ToList();
    }
}