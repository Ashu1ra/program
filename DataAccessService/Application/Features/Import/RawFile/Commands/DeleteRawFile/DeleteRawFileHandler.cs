using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Import.Rawfile.Commands.DeleteRawFile;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Rawfile.Commands.DeleteRawFile;

public class DeleteRawFileHandler : IRequestHandler<DeleteRawFileCommand, Unit>
{
    private readonly IRepository<RawFile> _repo;
    private readonly IUnitOfWork _uow;
    private readonly AclGuard _acl;

    public DeleteRawFileHandler(
        IRepository<RawFile> repo,
        IUnitOfWork uow,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _acl = acl;
    }

    public async Task<Unit> Handle(DeleteRawFileCommand request, CancellationToken ct)
    {
        // 1. Проверка доступа
        await _acl.RequireDeleteAsync("import", "raw_file", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"RawFile {request.Id} not found");

        _repo.Remove(entity);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}