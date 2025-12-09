using DataAccessService.Application.DTO.Igt;
using MediatR;

namespace DataAccessService.Application.Features.Igt.Boreholes.Queries.GetBoreholeList;

public record GetBoreholeListQuery()
    : IRequest<IReadOnlyList<BoreholeResponseDto>>;