using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.BimModels.Queries.GetBimModelList;

public record GetBimModelListQuery()
    : IRequest<IReadOnlyList<BimModelResponseDto>>;