using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Commands.CreateBoreholeIntervalType;

public class CreateBoreholeIntervalTypeHandler
    : IRequestHandler<CreateBoreholeIntervalTypeCommand, long>
{
    private readonly IRepository<ListBoreholeIntervalType> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateBoreholeIntervalTypeHandler(
        IRepository<ListBoreholeIntervalType> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateBoreholeIntervalTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_borehole_interval_type", null, ct);

        var dto = request.Dto;

        var entity = ListBoreholeIntervalType.Create(
            Mnemonic.Create(dto.Mnemonic),
            Name.Create(dto.Name),
            dto.Metadata,
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}