using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.BoreholeIntervals.Commands.CreateBoreholeInterval;
using DataAccessService.Application.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Commands.CreateBoreholeInterval;

public class CreateBoreholeIntervalHandler
    : IRequestHandler<CreateBoreholeIntervalCommand, long>
{
    private readonly IRepository<BoreholeInterval> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateBoreholeIntervalHandler(
        IRepository<BoreholeInterval> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateBoreholeIntervalCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("igt", "borehole_interval", null, ct);

        var dto = request.Dto;

        var entity = BoreholeInterval.Create(
            borehole: dto.LinkBorehole,
            interval: dto.Interval.ToValueObject(),
            linkListBoreholeIntervalType: dto.LinkListBoreholeIntervalType,
            metadata: dto.Metadata ?? "{}",
            ownerUserId: _current.UserId
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}