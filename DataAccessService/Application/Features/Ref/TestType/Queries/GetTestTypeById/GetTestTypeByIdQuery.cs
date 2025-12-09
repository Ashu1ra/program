using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.TestType.Queries.GetTestTypeById;

public record GetTestTypeByIdQuery(long Id)
    : IRequest<ListTestTypeResponseDto>;