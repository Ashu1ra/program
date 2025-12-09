using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.SampleStandard.Queries.GetSampleStandardById;

public record GetSampleStandardByIdQuery(long Id)
    : IRequest<ListSampleStandardResponseDto>;