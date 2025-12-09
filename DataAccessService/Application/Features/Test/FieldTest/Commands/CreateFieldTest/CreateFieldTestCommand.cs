using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Commands.CreateFieldTest;

public record CreateFieldTestCommand(CreateFieldTestDto Dto)
    : IRequest<long>;