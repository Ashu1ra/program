using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Features.Import.RawfileEntityLink.Queries.GetRawFileEntityLinkById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Queries.GetRawFileEntityLinkById;

public class GetRawFileEntityLinkByIdHandler
    : IRequestHandler<GetRawFileEntityLinkByIdQuery, RawFileEntityLinkResponseDto>
{
    private readonly IReadOnlyRepository<RawFileEntityLink> _repo;
    private readonly AclGuard _acl;

    public GetRawFileEntityLinkByIdHandler(
        IReadOnlyRepository<RawFileEntityLink> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<RawFileEntityLinkResponseDto> Handle(GetRawFileEntityLinkByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "raw_file_entity_link", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("RawFileEntityLink not found");

        return new RawFileEntityLinkResponseDto(
            entity.Id,
            entity.RawFileId,
            entity.EntitySchema,
            entity.EntityName,
            entity.ObjectId
        );
    }
}