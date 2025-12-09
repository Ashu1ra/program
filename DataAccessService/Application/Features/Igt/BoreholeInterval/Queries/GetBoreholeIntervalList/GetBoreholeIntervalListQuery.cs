using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.BoreholeIntervals.Queries.GetBoreholeIntervalList;

public record GetBoreholeIntervalListQuery(long LinkBorehole)
    : IRequest<IReadOnlyList<BoreholeIntervalResponseDto>>;
