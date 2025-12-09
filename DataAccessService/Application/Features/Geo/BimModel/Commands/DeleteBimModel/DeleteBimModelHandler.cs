using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Geo.BimModels.Commands.DeleteBimModel;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Commands.DeleteBimModel;

public class DeleteBimModelHandler : IRequestHandler<DeleteBimModelCommand, Unit>
{
    private readonly IRepository<BimModel> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteBimModelHandler(IRepository<BimModel> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteBimModelCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("geo", "bim_model", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("BimModel not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}