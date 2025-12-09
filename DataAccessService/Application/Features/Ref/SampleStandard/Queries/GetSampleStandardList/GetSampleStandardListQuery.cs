using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Queries.GetSampleStandardList;

public record GetSampleStandardListQuery()
    : IRequest<IReadOnlyList<ListSampleStandardResponseDto>>;