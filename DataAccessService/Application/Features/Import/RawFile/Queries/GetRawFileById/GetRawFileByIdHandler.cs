using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Features.Import.Rawfile.Queries.GetRawFileById;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Queries.GetRawFileById;

public class GetRawFileByIdHandler
    : IRequestHandler<GetRawFileByIdQuery, RawFileResponseDto>
{
    private readonly IReadOnlyRepository<RawFile> _repo;
    private readonly AclGuard _acl;

    public GetRawFileByIdHandler(
        IReadOnlyRepository<RawFile> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<RawFileResponseDto> Handle(GetRawFileByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "raw_file", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("RawFile not found");

        return new RawFileResponseDto(
            entity.Id,
            entity.LinkDataSource,
            entity.FileName.Value,
            entity.LinkListFileFormat,
            entity.SourceLink.Value,
            entity.UploadAt,
            entity.OwnerUserId
        );
    }
}
