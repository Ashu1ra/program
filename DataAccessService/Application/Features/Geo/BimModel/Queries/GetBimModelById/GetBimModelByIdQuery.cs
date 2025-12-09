using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Queries.GetBimModelById;

public record GetBimModelByIdQuery(long Id)
    : IRequest<BimModelResponseDto>;