using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Queries.GetBoreholeIntervalTypeList;

public record GetBoreholeIntervalTypeListQuery()
    : IRequest<IReadOnlyList<ListBoreholeIntervalTypeResponseDto>>;