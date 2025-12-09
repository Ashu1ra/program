using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Fieldtest.Commands.CreateFieldTest;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Commands.CreateFieldTest;

public class CreateFieldTestHandler
    : IRequestHandler<CreateFieldTestCommand, long>
{
    private readonly IRepository<FieldTest> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateFieldTestHandler(
        IRepository<FieldTest> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateFieldTestCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("test", "field_test", null, ct);

        var dto = request.Dto;

        var entity = FieldTest.Create(
            interval: dto.LinkBoreholeInterval,
            linkListTestType: dto.LinkListTestType,
            results: dto.Results,
            testDate: dto.TestDate,
            metadata: dto.Metadata ?? "{}",
            ownerUserId: _current.UserId
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}