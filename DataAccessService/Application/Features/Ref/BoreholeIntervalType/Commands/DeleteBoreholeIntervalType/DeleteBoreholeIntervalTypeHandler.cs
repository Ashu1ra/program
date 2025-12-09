using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Commands.DeleteBoreholeIntervalType;

public class DeleteBoreholeIntervalTypeHandler
    : IRequestHandler<DeleteBoreholeIntervalTypeCommand, Unit>
{
    private readonly IRepository<ListBoreholeIntervalType> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteBoreholeIntervalTypeHandler(
        IRepository<ListBoreholeIntervalType> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteBoreholeIntervalTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("ref", "list_borehole_interval_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new NotFoundException("ListBoreholeIntervalType not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}