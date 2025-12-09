using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Import;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Queries.GetDataSourceList;

public class GetDataSourceListHandler
    : IRequestHandler<GetDataSourceListQuery, IReadOnlyList<DataSourceResponseDto>>
{
    private readonly IReadOnlyRepository<DataSource> _repo;
    private readonly AclGuard _acl;

    public GetDataSourceListHandler(
        IReadOnlyRepository<DataSource> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<DataSourceResponseDto>> Handle(GetDataSourceListQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("import", "data_source", null, ct);

        var items = await _repo.GetAllAsync(ct);

        return items.Select(e =>
            new DataSourceResponseDto(
                e.Id,
                e.Name.Value,
                e.LinkListSourceType,
                e.SourceLink.Value,
                e.Description,
                e.OwnerUserId
            )
        ).ToList();
    }
}