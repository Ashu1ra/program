using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Commands.DeleteSourceType;

public class DeleteSourceTypeHandler : IRequestHandler<DeleteSourceTypeCommand, Unit>
{
    private readonly IRepository<ListSourceType> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteSourceTypeHandler(
        IRepository<ListSourceType> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteSourceTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("ref", "list_source_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListSourceType not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}