using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Commands.DeleteTestType;

public record DeleteTestTypeCommand(long Id)
    : IRequest<Unit>;