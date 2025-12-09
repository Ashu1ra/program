using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.DTO.Test;
using DataAccessService.Application.Features.Test.Labtest.Commands.CreateLabTest;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Commands.CreateLabTest;

public class CreateLabTestHandler
    : IRequestHandler<CreateLabTestCommand, long>
{
    private readonly IRepository<LabTest> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateLabTestHandler(
        IRepository<LabTest> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateLabTestCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("test", "lab_test", null, ct);

        var dto = request.Dto;

        var entity = LabTest.Create(
            linkSampl: dto.LinkSample,
            linkListTestType: dto.LinkListTestType,
            results: dto.Results,
            TestDate: dto.TestDate,
            metadata: dto.Metadata ?? "{}",
            ownerUserId: _current.UserId
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}