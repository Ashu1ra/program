using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Labtest.Queries.GetLabTestList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Queries.GetLabTestList;

public class GetLabTestListHandler
    : IRequestHandler<GetLabTestListQuery, IReadOnlyList<LabTestResponseDto>>
{
    private readonly IReadOnlyRepository<LabTest> _repo;
    private readonly AclGuard _acl;

    public GetLabTestListHandler(
        IReadOnlyRepository<LabTest> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<LabTestResponseDto>> Handle(
        GetLabTestListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("test", "lab_test", null, ct);

        var all = await _repo.GetAllAsync(ct);

        return all
            .Where(x => x.LinkSample == request.LinkSample)
            .Select(e => new LabTestResponseDto(
                e.Id,
                e.LinkSample,
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