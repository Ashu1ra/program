using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.DTO.Igt;
using DataAccessService.Application.Features.Igt.Boreholes.Commands.CreateBorehole;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Commands.CreateBorehole;

public class CreateBoreholeHandler : IRequestHandler<CreateBoreholeCommand, long>
{
    private readonly IRepository<Borehole> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateBoreholeHandler(
        IRepository<Borehole> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateBoreholeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("igt", "borehole", null, ct);

        var dto = request.Dto;

        var entity = Borehole.Create(
            site: dto.LinkSite,
            location: PointZMapper.ToDomain(dto.Location),
            linkListBoreholeType: dto.LinkListBoreholeType,
            dmin: dto.DepthMin,
            dmax: dto.DepthMax,
            linkListBoreholeStandard: dto.LinkListBoreholeStandard,
            dateStart: dto.DateStart,
            dateEnd: dto.DateEnd ?? dto.DateStart,
            metadata: dto.Metadata ?? "{}",
            ownerUserId: _current.UserId
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}