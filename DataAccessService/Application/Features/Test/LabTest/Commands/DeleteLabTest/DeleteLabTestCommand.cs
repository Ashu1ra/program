using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Commands.DeleteLabTest;

public record DeleteLabTestCommand(long Id)
    : IRequest<Unit>;