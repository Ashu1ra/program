using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Fieldtest.Commands.UpdateFieldTest;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Commands.UpdateFieldTest;

public class UpdateFieldTestHandler : IRequestHandler<UpdateFieldTestCommand, Unit>
{
    private readonly IRepository<FieldTest> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateFieldTestHandler(
        IRepository<FieldTest> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateFieldTestCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("test", "field_test", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("FieldTest not found");

        var dto = request.Dto;

        entity.UpdateResults(dto.Results);
        entity.UpdateMetadata(dto.Metadata ?? "{}");

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}