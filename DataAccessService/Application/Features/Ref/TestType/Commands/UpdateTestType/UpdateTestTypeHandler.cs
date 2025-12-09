using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Commands.UpdateTestType;

public class UpdateTestTypeHandler
    : IRequestHandler<UpdateTestTypeCommand, Unit>
{
    private readonly IRepository<ListTestType> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateTestTypeHandler(
        IRepository<ListTestType> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateTestTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_test_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListTestType not found");

        var dto = request.Dto;

        entity.Rename(Name.Create(dto.Name));
        entity.UpdateDescription(dto.Description);
        entity.UpdateCode(Code.Create(dto.Code));
        entity.UpdateCategory(TestCategory.Create(dto.Category));

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}