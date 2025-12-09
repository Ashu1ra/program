using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Features.Import.Rawfile.Queries.GetRawFileList;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Queries.GetRawFileList;

public class GetRawFileListHandler
    : IRequestHandler<GetRawFileListQuery, IReadOnlyList<RawFileResponseDto>>
{
    private readonly IReadOnlyRepository<RawFile> _repo;
    private readonly AclGuard _acl;

    public GetRawFileListHandler(
        IReadOnlyRepository<RawFile> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<RawFileResponseDto>> Handle(GetRawFileListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "raw_file", null, ct);

        var entities = await _repo.GetAllAsync(ct);

        return entities.Select(e =>
            new RawFileResponseDto(
                e.Id,
                e.LinkDataSource,
                e.FileName.Value,
                e.LinkListFileFormat,
                e.SourceLink.Value,
                e.UploadAt,
                e.OwnerUserId
            )
        ).ToList();
    }
}