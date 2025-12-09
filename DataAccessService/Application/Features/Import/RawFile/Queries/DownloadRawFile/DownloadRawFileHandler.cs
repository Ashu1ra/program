using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Features.Import.Rawfile.Queries.DownloadRawFile;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Queries.DownloadRawFile;

public class DownloadRawFileHandler
    : IRequestHandler<DownloadRawFileQuery, DownloadRawFileDto>
{
    private readonly IReadOnlyRepository<RawFile> _repo;
    private readonly AclGuard _acl;

    public DownloadRawFileHandler(
        IReadOnlyRepository<RawFile> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<DownloadRawFileDto> Handle(DownloadRawFileQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "raw_file", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("RawFile not found");

        string contentType = "application/octet-stream"; // можно улучшить позже

        return new DownloadRawFileDto(
            FileName: entity.FileName.Value,
            ContentType: contentType,
            FileData: entity.FileData
        );
    }
}
