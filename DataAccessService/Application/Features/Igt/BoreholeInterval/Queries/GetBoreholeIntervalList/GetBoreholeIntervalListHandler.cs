using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.BoreholeIntervals.Queries.GetBoreholeIntervalList;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Queries.GetBoreholeIntervalList;

public class GetBoreholeIntervalListHandler
    : IRequestHandler<GetBoreholeIntervalListQuery, IReadOnlyList<BoreholeIntervalResponseDto>>
{
    private readonly IReadOnlyRepository<BoreholeInterval> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeIntervalListHandler(
        IReadOnlyRepository<BoreholeInterval> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<BoreholeIntervalResponseDto>> Handle(
        GetBoreholeIntervalListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("igt", "borehole_interval", null, ct);

        var all = await _repo.GetAllAsync(ct);

        return all
            .Where(x => x.LinkBorehole == request.LinkBorehole)
            .Select(e => new BoreholeIntervalResponseDto(
                e.Id,
                e.LinkBorehole,
                e.Interval.ToDto(),
                e.LinkListBoreholeIntervalType,
                e.Metadata,
                e.CreatedAt,
                e.UpdatedAt,
                e.OwnerUserId
            ))
            .ToList();
    }
}