using Application.Features.Igt.Borehole.Commands.UpdateBorehole;
using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Common.Mappers;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Commands.UpdateBorehole;

public class UpdateBoreholeHandler
    : IRequestHandler<UpdateBoreholeCommand, Unit>
{
    private readonly IRepository<Borehole> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateBoreholeHandler(IRepository<Borehole> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateBoreholeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("igt", "borehole", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Borehole not found");

        var dto = request.Dto;

        if (dto.DepthMax is not null)
            entity.UpdateDepthMax(dto.DepthMax.Value);

        if (dto.DateEnd is not null)
            entity.UpdateDateEnd(dto.DateEnd);

        if (dto.Metadata is not null)
            entity.UpdateMetadata(dto.Metadata);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
