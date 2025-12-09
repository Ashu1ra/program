using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Commands.CreateSampleStandard;

public class CreateSampleStandardHandler
    : IRequestHandler<CreateSampleStandardCommand, long>
{
    private readonly IRepository<ListSampleStandard> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateSampleStandardHandler(
        IRepository<ListSampleStandard> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateSampleStandardCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_sample_standard", null, ct);

        var dto = request.Dto;

        var entity = ListSampleStandard.Create(
            Mnemonic.Create(dto.Mnemonic),
            Name.Create(dto.Name),
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}