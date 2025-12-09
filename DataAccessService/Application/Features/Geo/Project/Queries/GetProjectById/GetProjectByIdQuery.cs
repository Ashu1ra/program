using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Queries.GetProjectById;

public record GetProjectByIdQuery(long Id)
    : IRequest<ProjectResponseDto>;
