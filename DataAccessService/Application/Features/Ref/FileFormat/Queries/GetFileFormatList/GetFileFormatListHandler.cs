using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Ref;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Queries.GetFileFormatList;

public class GetFileFormatListHandler
    : IRequestHandler<GetFileFormatListQuery, IReadOnlyList<ListFileFormatResponseDto>>
{
    private readonly IReadOnlyRepository<ListFileFormat> _repo;
    private readonly AclGuard _acl;

    public GetFileFormatListHandler(
        IReadOnlyRepository<ListFileFormat> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<ListFileFormatResponseDto>> Handle(GetFileFormatListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("ref", "list_file_format", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(e =>
            new ListFileFormatResponseDto(
                e.Id,
                e.Mnemonic.Value,
                e.Name.Value,
                e.Metadata,
                e.Description
            )
        ).ToList();
    }
}