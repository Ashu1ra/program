using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Queries.GetSourceTypeList;

public class GetSourceTypeListHandler
    : IRequestHandler<GetSourceTypeListQuery, IReadOnlyList<ListSourceTypeResponseDto>>
{
    private readonly IReadOnlyRepository<ListSourceType> _repo;
    private readonly AclGuard _acl;

    public GetSourceTypeListHandler(
        IReadOnlyRepository<ListSourceType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListSourceTypeResponseDto>> Handle(GetSourceTypeListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_source_type", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(e =>
            new ListSourceTypeResponseDto(e.Id,e.Mnemonic.Value, e.Name.Value, e.Description)
        ).ToList();
    }
}