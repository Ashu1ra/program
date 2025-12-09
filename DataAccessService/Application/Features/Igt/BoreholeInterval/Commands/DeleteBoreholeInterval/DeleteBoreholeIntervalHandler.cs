using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Igt.BoreholeIntervals.Commands.DeleteBoreholeInterval;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Commands.DeleteBoreholeInterval;

public class DeleteBoreholeIntervalHandler
    : IRequestHandler<DeleteBoreholeIntervalCommand, Unit>
{
    private readonly IRepository<BoreholeInterval> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteBoreholeIntervalHandler(
        IRepository<BoreholeInterval> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteBoreholeIntervalCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("igt", "borehole_interval", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("BoreholeInterval not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}