using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Queries.GetDataSourceById;

public class GetDataSourceByIdHandler
    : IRequestHandler<GetDataSourceByIdQuery, DataSourceResponseDto>
{
    private readonly IReadOnlyRepository<DataSource> _repo;
    private readonly AclGuard _acl;

    public GetDataSourceByIdHandler(
        IReadOnlyRepository<DataSource> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<DataSourceResponseDto> Handle(GetDataSourceByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "data_source", request.Id, ct);

        var entity = await _repo.GetByIdAsync(request.Id, ct);
        if (entity is null)
            throw new NotFoundException($"DataSource {request.Id} not found");

        return new DataSourceResponseDto(
            entity.Id,
            entity.Name.Value,
            entity.LinkListSourceType,
            entity.SourceLink.Value,
            entity.Description,
            entity.OwnerUserId
        );
    }
}