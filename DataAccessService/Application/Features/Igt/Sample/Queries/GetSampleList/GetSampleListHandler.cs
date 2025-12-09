using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Samples.Queries.GetSampleList;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Queries.GetSampleList;

public class GetSampleListHandler
    : IRequestHandler<GetSampleListQuery, IReadOnlyList<SampleResponseDto>>
{
    private readonly IReadOnlyRepository<Sample> _repo;
    private readonly AclGuard _acl;

    public GetSampleListHandler(
        IReadOnlyRepository<Sample> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<SampleResponseDto>> Handle(
        GetSampleListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("igt", "sample", null, ct);

        var all = await _repo.GetAllAsync(ct);

        return all
            .Where(x => x.LinkBoreholeInterval == request.LinkBoreholeInterval)
            .Select(e => new SampleResponseDto(
                e.Id,
                e.LinkBoreholeInterval,
                e.Number.Value,
                e.Interval.ToDto(),
                e.LinkListSampleStandard,
                e.Description,
                e.CreatedAt,
                e.UpdatedAt,
                e.OwnerUserId
            ))
            .ToList();
    }
}