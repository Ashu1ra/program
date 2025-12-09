using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Commands.CreateDataSource;

public record CreateDataSourceCommand(CreateDataSourceDto Dto)
    : IRequest<long>;
