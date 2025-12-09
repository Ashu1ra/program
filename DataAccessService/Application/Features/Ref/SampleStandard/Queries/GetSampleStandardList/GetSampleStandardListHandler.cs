using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Queries.GetSampleStandardList;

public class GetSampleStandardListHandler
    : IRequestHandler<GetSampleStandardListQuery, IReadOnlyList<ListSampleStandardResponseDto>>
{
    private readonly IReadOnlyRepository<ListSampleStandard> _repo;
    private readonly AclGuard _acl;

    public GetSampleStandardListHandler(
        IReadOnlyRepository<ListSampleStandard> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListSampleStandardResponseDto>> Handle(
        GetSampleStandardListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_sample_standard", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(entity =>
            new ListSampleStandardResponseDto(
                entity.Id,
                entity.Mnemonic.Value,
                entity.Name.Value,
                entity.Description
            )
        ).ToList();
    }
}