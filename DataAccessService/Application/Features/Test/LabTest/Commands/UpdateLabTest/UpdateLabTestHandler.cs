using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Labtest.Commands.UpdateLabTest;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Commands.UpdateLabTest;

public class UpdateLabTestHandler
    : IRequestHandler<UpdateLabTestCommand, Unit>
{
    private readonly IRepository<LabTest> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public UpdateLabTestHandler(
        IRepository<LabTest> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(UpdateLabTestCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("test", "lab_test", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct)
            ?? throw new NotFoundException("LabTest not found");

        var dto = request.Dto;

        entity.UpdateResults(dto.Results);
        entity.UpdateMetadata(dto.Metadata ?? "{}");

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}