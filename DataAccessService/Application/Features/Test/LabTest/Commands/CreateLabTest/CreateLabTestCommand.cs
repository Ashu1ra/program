using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Commands.CreateLabTest;

public record CreateLabTestCommand(CreateLabTestDto Dto)
    : IRequest<long>;