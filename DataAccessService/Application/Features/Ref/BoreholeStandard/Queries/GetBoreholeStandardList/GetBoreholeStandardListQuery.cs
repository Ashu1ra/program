using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Queries.GetBoreholeStandardList;

public record GetBoreholeStandardListQuery()
    : IRequest<IReadOnlyList<ListBoreholeStandardResponseDto>>;