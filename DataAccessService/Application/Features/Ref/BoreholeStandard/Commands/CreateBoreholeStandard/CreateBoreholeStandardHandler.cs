using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Commands.CreateBoreholeStandard;

public class CreateBoreholeStandardHandler
    : IRequestHandler<CreateBoreholeStandardCommand, long>
{
    private readonly IRepository<ListBoreholeStandard> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateBoreholeStandardHandler(
        IRepository<ListBoreholeStandard> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateBoreholeStandardCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_borehole_standard", null, ct);

        var dto = request.Dto;

        var entity = ListBoreholeStandard.Create(
            Mnemonic.Create(dto.Mnemonic),
            Name.Create(dto.Name),
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}