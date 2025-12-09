using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Queries.GetTestTypeList;

public class GetTestTypeListHandler
    : IRequestHandler<GetTestTypeListQuery, IReadOnlyList<ListTestTypeResponseDto>>
{
    private readonly IReadOnlyRepository<ListTestType> _repo;
    private readonly AclGuard _acl;

    public GetTestTypeListHandler(
        IReadOnlyRepository<ListTestType> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListTestTypeResponseDto>> Handle(GetTestTypeListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_test_type", null, ct);

        var entities = await _repo.GetAllAsync(ct);

        return entities.Select(e =>
            new ListTestTypeResponseDto(
                e.Id,
                e.Mnemonic.Value,
                e.Code.Value,
                e.Name.Value,
                e.Category.Value,
                e.Description
            )
        ).ToList();
    }
}