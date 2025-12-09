using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Queries.GetDataSourceList;

public record GetDataSourceListQuery()
    : IRequest<IReadOnlyList<DataSourceResponseDto>>;