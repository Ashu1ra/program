using DataAccessService.Application.DTO.Import;
using MediatR;

namespace DataAccessService.Application.Features.Import.Datasource.Commands.UpdateDataSource;

public record UpdateDataSourceCommand(long Id, UpdateDataSourceDto Dto)
    : IRequest<Unit>;