using DataAccessService.Application.DTO.Ref;
using MediatR;

namespace DataAccessService.Application.Features.Ref.BoreholeStandard.Queries.GetBoreholeStandardById;

public record GetBoreholeStandardByIdQuery(long Id)
    : IRequest<ListBoreholeStandardResponseDto>;