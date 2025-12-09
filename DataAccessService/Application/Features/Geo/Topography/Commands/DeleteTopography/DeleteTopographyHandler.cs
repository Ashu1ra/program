using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Geo.Topographys.Commands.DeleteTopography;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Topographys.Commands.DeleteTopography;

public class DeleteTopographyHandler : IRequestHandler<DeleteTopographyCommand, Unit>
{
    private readonly IRepository<Topography> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteTopographyHandler(IRepository<Topography> repo, IUnitOfWork uow, AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteTopographyCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("geo", "topography", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("Topography not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}