using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeIntervalType.Queries.GetBoreholeIntervalTypeById;

public record GetBoreholeIntervalTypeByIdQuery(long Id)
    : IRequest<ListBoreholeIntervalTypeResponseDto>;