using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Commands.DeleteBoreholeStandard;

public class DeleteBoreholeStandardHandler
    : IRequestHandler<DeleteBoreholeStandardCommand, Unit>
{
    private readonly IRepository<ListBoreholeStandard> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteBoreholeStandardHandler(
        IRepository<ListBoreholeStandard> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteBoreholeStandardCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("ref", "list_borehole_standard", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListBoreholeStandard not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}