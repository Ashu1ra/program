using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.Features.Import.Datasource.Commands.UpdateDataSource;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Commands.UpdateDataSource;

public class UpdateDataSourceHandler
    : IRequestHandler<UpdateDataSourceCommand, Unit>
{
    private readonly IRepository<DataSource> _repo;
    private readonly AclGuard _acl;
    private readonly IUnitOfWork _uow;

    public UpdateDataSourceHandler(
        IRepository<DataSource> repo,
        AclGuard acl,
        IUnitOfWork uow)
    {
        _repo = repo;
        _acl = acl;
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateDataSourceCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("import", "data_source", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException("DataSource not found");

        entity.UpdateDescription(request.Dto.Description);

        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}