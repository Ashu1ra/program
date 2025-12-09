using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.BoreholeIntervals.Queries.GetBoreholeIntervalById;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Queries.GetBoreholeIntervalById;

public class GetBoreholeIntervalByIdHandler
    : IRequestHandler<GetBoreholeIntervalByIdQuery, BoreholeIntervalResponseDto>
{
    private readonly IReadOnlyRepository<BoreholeInterval> _repo;
    private readonly AclGuard _acl;

    public GetBoreholeIntervalByIdHandler(
        IReadOnlyRepository<BoreholeInterval> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<BoreholeIntervalResponseDto> Handle(GetBoreholeIntervalByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("igt", "borehole_interval", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("BoreholeInterval not found");

        return new BoreholeIntervalResponseDto(
            entity.Id,
            entity.LinkBorehole,
            entity.Interval.ToDto(),
            entity.LinkListBoreholeIntervalType,
            entity.Metadata,
            entity.CreatedAt,
            entity.UpdatedAt,
            entity.OwnerUserId
        );
    }
}
