using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Commands.CreateTestType;

public class CreateTestTypeHandler
    : IRequestHandler<CreateTestTypeCommand, long>
{
    private readonly IRepository<ListTestType> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateTestTypeHandler(
        IRepository<ListTestType> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateTestTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_test_type", null, ct);

        var dto = request.Dto;

        var entity = ListTestType.Create(
            Mnemonic.Create(dto.Mnemonic),
            Code.Create(dto.Code),
            Name.Create(dto.Name),
            TestCategory.Create(dto.Category),
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}