using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Queries.GetBoreholeTypeList;

public record GetBoreholeTypeListQuery()
    : IRequest<IReadOnlyList<ListBoreholeTypeResponseDto>>;