using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Commands.UpdateProject;

public record UpdateProjectCommand(long Id, UpdateProjectDto Dto)
    : IRequest<Unit>;
