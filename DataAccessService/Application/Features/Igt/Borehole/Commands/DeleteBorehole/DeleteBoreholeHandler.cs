using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Igt.Boreholes.Commands.DeleteBorehole;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Commands.DeleteBorehole;

public class DeleteBoreholeHandler : IRequestHandler<DeleteBoreholeCommand, Unit>
{
    private readonly IRepository<Borehole> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteBoreholeHandler(
        IRepository<Borehole> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteBoreholeCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("igt", "borehole", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Borehole not found");

        _repo.Remove(entity);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}