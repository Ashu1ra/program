using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Commands.DeleteDataSource;

public record DeleteDataSourceCommand(long Id)
    : IRequest<Unit>;