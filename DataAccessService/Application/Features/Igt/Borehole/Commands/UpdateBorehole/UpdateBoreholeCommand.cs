using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Commands.UpdateBorehole;

public record UpdateBoreholeCommand(long Id, UpdateBoreholeDto Dto)
    : IRequest<Unit>;
