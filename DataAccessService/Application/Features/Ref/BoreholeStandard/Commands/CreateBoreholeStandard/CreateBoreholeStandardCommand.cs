using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Commands.CreateBoreholeStandard;

public record CreateBoreholeStandardCommand(CreateListBoreholeStandardDto Dto)
    : IRequest<long>;