using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Commands.UpdateBoreholeStandard;

public class UpdateBoreholeStandardHandler
    : IRequestHandler<UpdateBoreholeStandardCommand, Unit>
{
    private readonly IRepository<ListBoreholeStandard> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateBoreholeStandardHandler(
        IRepository<ListBoreholeStandard> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateBoreholeStandardCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_borehole_standard", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListBoreholeStandard not found");

        var dto = request.Dto;

        entity.Rename(Name.Create(dto.Name));
        entity.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}