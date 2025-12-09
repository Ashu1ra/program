using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Queries.GetDataSourceById;

public record GetDataSourceByIdQuery(long Id) : IRequest<DataSourceResponseDto>;