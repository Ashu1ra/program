using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Commands.UpdateSourceType;

public record UpdateSourceTypeCommand(long Id, UpdateListSourceTypeDto Dto) : IRequest<Unit>;