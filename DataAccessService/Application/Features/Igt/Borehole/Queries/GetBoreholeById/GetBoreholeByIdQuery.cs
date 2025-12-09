using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Queries.GetBoreholeById;

public record GetBoreholeByIdQuery(long Id)
    : IRequest<BoreholeResponseDto>;
