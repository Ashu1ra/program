using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Commands.UpdateBoreholeStandard;

public record UpdateBoreholeStandardCommand(long Id, UpdateListBoreholeStandardDto Dto)
    : IRequest<Unit>;