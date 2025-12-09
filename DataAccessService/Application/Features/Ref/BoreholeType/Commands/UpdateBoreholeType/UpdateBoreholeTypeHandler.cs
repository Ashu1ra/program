using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Commands.UpdateBoreholeType;

public class UpdateBoreholeTypeHandler : IRequestHandler<UpdateBoreholeTypeCommand, Unit>
{
    private readonly IRepository<ListBoreholeType> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateBoreholeTypeHandler(
        IRepository<ListBoreholeType> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateBoreholeTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_borehole_type", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("ListBoreholeType not found");

        var dto = request.Dto;

        entity.Rename(Name.Create(dto.Name));
        entity.UpdateDescription(dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}