using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Features.Import.RawfileEntityLink.Queries.GetRawFileEntityLinks;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.RawfileEntityLink.Queries.GetRawFileEntityLinks;

public class GetRawFileEntityLinksHandler
    : IRequestHandler<GetRawFileEntityLinksQuery, IReadOnlyList<RawFileEntityLinkResponseDto>>
{
    private readonly IReadOnlyRepository<RawFileEntityLink> _repo;
    private readonly AclGuard _acl;

    public GetRawFileEntityLinksHandler(
        IReadOnlyRepository<RawFileEntityLink> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<RawFileEntityLinkResponseDto>> Handle(
        GetRawFileEntityLinksQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "raw_file_entity_link", null, ct);

        var allLinks = await _repo.GetAllAsync(ct);

        return allLinks
            .Where(l => l.RawFileId == request.RawFileId)
            .Select(l => new RawFileEntityLinkResponseDto(
                l.Id,
                l.RawFileId,
                l.EntitySchema,
                l.EntityName,
                l.ObjectId
            ))
            .ToList();
    }
}