using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Commands.UpdateTestType;

public record UpdateTestTypeCommand(long Id, UpdateListTestTypeDto Dto)
    : IRequest<Unit>;