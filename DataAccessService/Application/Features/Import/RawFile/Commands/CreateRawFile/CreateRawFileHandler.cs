using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Commands.CreateRawFile;

public class CreateRawFileHandler : IRequestHandler<CreateRawFileCommand, long>
{
    private readonly IRepository<RawFile> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateRawFileHandler(
        IRepository<RawFile> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateRawFileCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("import", "raw_file", null, ct);

        var dto = request.Dto;

        var entity = RawFile.Create(
            linkDataSource: dto.LinkDataSource,
            filename: Name.Create(dto.FileName),
            format: dto.LinkListFileFormat,
            sourceLink: SourceLink.Create(dto.SourceLink),
            data: dto.FileData,
            ownerUserId: _current.UserId
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}
