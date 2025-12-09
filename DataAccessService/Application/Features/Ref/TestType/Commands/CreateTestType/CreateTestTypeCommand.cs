using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Commands.CreateTestType;

public record CreateTestTypeCommand(CreateListTestTypeDto Dto)
    : IRequest<long>;