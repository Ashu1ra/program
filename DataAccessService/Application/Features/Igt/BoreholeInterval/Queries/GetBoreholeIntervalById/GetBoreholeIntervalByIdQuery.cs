using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Queries.GetBoreholeIntervalById;

public record GetBoreholeIntervalByIdQuery(long Id)
    : IRequest<BoreholeIntervalResponseDto>;