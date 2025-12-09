using DataAccessService.Application.DTO.Test;
using MediatR;

namespace DataAccessService.Application.Features.Test.Labtest.Commands.UpdateLabTest;

public record UpdateLabTestCommand(long Id, UpdateLabTestDto Dto)
    : IRequest<Unit>;