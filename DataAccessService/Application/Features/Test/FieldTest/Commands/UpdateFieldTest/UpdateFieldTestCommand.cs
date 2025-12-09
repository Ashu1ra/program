using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Fieldtest.Commands.UpdateFieldTest;

public record UpdateFieldTestCommand(long Id, UpdateFieldTestDto Dto)
    : IRequest<Unit>;