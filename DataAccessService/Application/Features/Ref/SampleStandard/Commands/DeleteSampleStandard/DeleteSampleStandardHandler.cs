using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Commands.DeleteSampleStandard;

public class DeleteSampleStandardHandler
    : IRequestHandler<DeleteSampleStandardCommand, Unit>
{
    private readonly IRepository<ListSampleStandard> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteSampleStandardHandler(
        IRepository<ListSampleStandard> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteSampleStandardCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("ref", "list_sample_standard", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListSampleStandard not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}