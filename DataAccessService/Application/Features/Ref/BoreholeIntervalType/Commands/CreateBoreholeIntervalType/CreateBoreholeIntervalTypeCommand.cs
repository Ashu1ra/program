using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Commands.CreateBoreholeIntervalType;

public record CreateBoreholeIntervalTypeCommand(CreateListBoreholeIntervalTypeDto Dto)
    : IRequest<long>;