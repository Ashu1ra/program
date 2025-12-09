using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Queries.GetSampleList;

public record GetSampleListQuery(long LinkBoreholeInterval)
    : IRequest<IReadOnlyList<SampleResponseDto>>;