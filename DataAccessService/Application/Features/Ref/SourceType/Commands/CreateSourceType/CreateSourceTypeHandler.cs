using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Commands.CreateSourceType;

public class CreateSourceTypeHandler : IRequestHandler<CreateSourceTypeCommand, long>
{
    private readonly IRepository<ListSourceType> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public CreateSourceTypeHandler(
        IRepository<ListSourceType> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<long> Handle(CreateSourceTypeCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("ref", "list_source_type", null, ct);

        var dto = request.Dto;

        var entity = ListSourceType.Create(
            Mnemonic.Create(dto.Mnemonic),
            Name.Create(dto.Name),
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}