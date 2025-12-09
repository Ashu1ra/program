using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Import.RawfileEntityLink.Commands.DeleteRawFileEntityLink;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Commands.DeleteRawFileEntityLink;

public class DeleteRawFileEntityLinkHandler
    : IRequestHandler<DeleteRawFileEntityLinkCommand, Unit>
{
    private readonly IRepository<RawFileEntityLink> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteRawFileEntityLinkHandler(
        IRepository<RawFileEntityLink> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteRawFileEntityLinkCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("import", "raw_file_entity_link", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("RawFileEntityLink not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}