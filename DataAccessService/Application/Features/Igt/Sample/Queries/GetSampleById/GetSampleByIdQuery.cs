using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Samples.Queries.GetSampleById;

public record GetSampleByIdQuery(long Id)
    : IRequest<SampleResponseDto>;