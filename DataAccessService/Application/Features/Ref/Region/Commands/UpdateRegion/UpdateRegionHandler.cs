using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.Region.Commands.UpdateRegion;

public class UpdateRegionHandler
    : IRequestHandler<UpdateRegionCommand, Unit>
{
    private readonly IRepository<ListRegion> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateRegionHandler(
        IRepository<ListRegion> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateRegionCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_region", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new NotFoundException("ListRegion not found");

        var dto = request.Dto;

        entity.UpdateMnemonic(Mnemonic.Create(dto.Mnemonic));
        entity.UpdateCode(Code.Create(dto.Code));
        entity.UpdateName(Name.Create(dto.Name));

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}