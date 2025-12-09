using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Test.Fieldtest.Commands.DeleteFieldTest;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Commands.DeleteFieldTest;

public class DeleteFieldTestHandler
    : IRequestHandler<DeleteFieldTestCommand, Unit>
{
    private readonly IRepository<FieldTest> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteFieldTestHandler(
        IRepository<FieldTest> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteFieldTestCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("test", "field_test", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("FieldTest not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
