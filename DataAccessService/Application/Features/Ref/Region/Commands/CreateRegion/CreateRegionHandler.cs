using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Commands.CreateRegion;

public class CreateRegionHandler
    : IRequestHandler<CreateRegionCommand, long>
{
    private readonly IRepository<ListRegion> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateRegionHandler(
        IRepository<ListRegion> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateRegionCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_region", null, ct);

        var dto = request.Dto;

        var entity = ListRegion.Create(
            Mnemonic.Create(dto.Mnemonic),
            Code.Create(dto.Code),
            Name.Create(dto.Name)
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}