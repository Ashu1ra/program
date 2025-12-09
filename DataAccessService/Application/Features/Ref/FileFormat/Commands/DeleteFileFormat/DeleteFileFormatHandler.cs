using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.FileFormat.Commands.DeleteFileFormat;

public class DeleteFileFormatHandler : IRequestHandler<DeleteFileFormatCommand, Unit>
{
    private readonly IRepository<ListFileFormat> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteFileFormatHandler(
        IRepository<ListFileFormat> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteFileFormatCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("ref", "list_file_format", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new NotFoundException("ListFileFormat not found");

        _repo.Remove(entity);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}