using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Commands.UpdateBoreholeIntervalType;

public class UpdateBoreholeIntervalTypeHandler
    : IRequestHandler<UpdateBoreholeIntervalTypeCommand, Unit>
{
    private readonly IRepository<ListBoreholeIntervalType> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateBoreholeIntervalTypeHandler(
        IRepository<ListBoreholeIntervalType> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateBoreholeIntervalTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_borehole_interval_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListBoreholeIntervalType not found");

        var dto = request.Dto;

        entity.Rename(Name.Create(dto.Name));
        entity.UpdateDescription(dto.Description);

        if (dto.Metadata is not null)
            entity.UpdateMetadata(dto.Metadata);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}