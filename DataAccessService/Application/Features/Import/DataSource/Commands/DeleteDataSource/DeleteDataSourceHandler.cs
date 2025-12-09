using DataAccessService.Application.Features.Import.Datasource.Commands.DeleteDataSource;
using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Commands.DeleteDataSource;

public class DeleteDataSourceHandler
    : IRequestHandler<DeleteDataSourceCommand, Unit>
{
    private readonly IRepository<DataSource> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public DeleteDataSourceHandler(
        IRepository<DataSource> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteDataSourceCommand request, CancellationToken ct)
    {
        await _acl.RequireDeleteAsync("import", "data_source", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("DataSource not found");

        _repo.Remove(entity);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}