using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Fieldtest.Queries.GetFieldTestList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Queries.GetFieldTestList;

public class GetFieldTestListHandler
    : IRequestHandler<GetFieldTestListQuery, IReadOnlyList<FieldTestResponseDto>>
{
    private readonly IReadOnlyRepository<FieldTest> _repo;
    private readonly AclGuard _acl;

    public GetFieldTestListHandler(
        IReadOnlyRepository<FieldTest> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<FieldTestResponseDto>> Handle(
        GetFieldTestListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("test", "field_test", null, ct);

        var all = await _repo.GetAllAsync(ct);

        return all
            .Where(x => x.LinkBoreholeInterval == request.LinkBoreholeInterval)
            .Select(e => new FieldTestResponseDto(
                e.Id,
                e.LinkBoreholeInterval,
                e.LinkListTestType,
                e.Results ?? "{}",
                e.TestDate,
                e.Metadata,
                e.CreatedAt,
                e.UpdatedAt,
                e.OwnerUserId
            ))
            .ToList();
    }
}