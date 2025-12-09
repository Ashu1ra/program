using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Commands.CreateBorehole;

public record CreateBoreholeCommand(CreateBoreholeDto Dto)
    : IRequest<long>;
