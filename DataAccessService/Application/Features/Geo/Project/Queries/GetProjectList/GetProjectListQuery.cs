using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Queries.GetProjectList;

public record GetProjectListQuery()
    : IRequest<IReadOnlyList<ProjectResponseDto>>;