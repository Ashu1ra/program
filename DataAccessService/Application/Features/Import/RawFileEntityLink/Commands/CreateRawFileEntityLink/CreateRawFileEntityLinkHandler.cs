using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Commands.CreateRawFileEntityLink;

public class CreateRawFileEntityLinkHandler
    : IRequestHandler<CreateRawFileEntityLinkCommand, long>
{
    private readonly IRepository<RawFileEntityLink> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public CreateRawFileEntityLinkHandler(
        IRepository<RawFileEntityLink> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<long> Handle(CreateRawFileEntityLinkCommand request, CancellationToken ct)
    {
        var dto = request.Dto;

        await _acl.RequireWriteAsync("import", "raw_file_entity_link", null, ct);

        var link = RawFileEntityLink.Create(
            rawFileId: dto.RawFileId,
            schema: dto.EntitySchema,
            entity: dto.EntityName,
            objectId: dto.ObjectId
        );

        await _repo.AddAsync(link, ct);
        await _uow.SaveChangesAsync(ct);

        return link.Id;
    }
}