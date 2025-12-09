using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Abstractions.Services;
using DataAccessService.Application.Features.Import.Datasource.Commands.CreateDataSource;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Commands.CreateDataSource;

public class CreateDataSourceHandler
    : IRequestHandler<CreateDataSourceCommand, long>
{
    private readonly IRepository<DataSource> _repo;
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _current;
    private readonly AclGuard _acl;

    public CreateDataSourceHandler(
        IRepository<DataSource> repo,
        IUnitOfWork uow,
        ICurrentUserService current,
        AclGuard acl)
    {
        _repo = repo;
        _uow = uow;
        _current = current;
        _acl = acl;
    }

    public async Task<long> Handle(CreateDataSourceCommand request, CancellationToken ct)
    {
        await _acl.RequireWriteAsync("import", "data_source", null, ct);

        var dto = request.Dto;

        var entity = DataSource.Create(
            Name.Create(dto.Name),
            dto.SourceTypeId,
            _current.UserId,
            SourceLink.Create(dto.SourceLink),
            dto.Description
        );

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}