using MediatR;

namespace DataAccessService.Application.Features.Ref.SourceType.Commands.DeleteSourceType;

public record DeleteSourceTypeCommand(long Id) : IRequest<Unit>;