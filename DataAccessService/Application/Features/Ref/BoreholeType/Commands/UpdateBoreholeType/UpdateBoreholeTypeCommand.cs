using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Commands.UpdateBoreholeType;

public record UpdateBoreholeTypeCommand(long Id, UpdateListBoreholeTypeDto Dto)
    : IRequest<Unit>;