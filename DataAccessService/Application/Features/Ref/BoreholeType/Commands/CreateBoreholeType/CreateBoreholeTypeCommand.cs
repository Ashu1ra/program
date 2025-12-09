using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Commands.CreateBoreholeType;

public record CreateBoreholeTypeCommand(CreateListBoreholeTypeDto Dto)
    : IRequest<long>;