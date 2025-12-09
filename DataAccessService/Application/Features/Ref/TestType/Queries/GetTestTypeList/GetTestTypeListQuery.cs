using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Queries.GetTestTypeList;

public record GetTestTypeListQuery()
    : IRequest<IReadOnlyList<ListTestTypeResponseDto>>;