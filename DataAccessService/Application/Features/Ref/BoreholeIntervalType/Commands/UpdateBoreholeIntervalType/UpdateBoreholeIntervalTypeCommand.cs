using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Commands.UpdateBoreholeIntervalType;

public record UpdateBoreholeIntervalTypeCommand(long Id, UpdateListBoreholeIntervalTypeDto Dto)
    : IRequest<Unit>;