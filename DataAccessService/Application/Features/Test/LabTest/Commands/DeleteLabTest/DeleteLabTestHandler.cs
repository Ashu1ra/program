using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Test.Labtest.Commands.DeleteLabTest;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Commands.DeleteLabTest;

public class DeleteLabTestHandler
    : IRequestHandler<DeleteLabTestCommand, Unit>
{
    private readonly IRepository<LabTest> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteLabTestHandler(
        IRepository<LabTest> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteLabTestCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("test", "lab_test", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("LabTest not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}