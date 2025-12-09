using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Commands.DeleteFieldTest;

public record DeleteFieldTestCommand(long Id)
    : IRequest<Unit>;