using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeType.Queries.GetBoreholeTypeById;

public record GetBoreholeTypeByIdQuery(long Id)
    : IRequest<ListBoreholeTypeResponseDto>;