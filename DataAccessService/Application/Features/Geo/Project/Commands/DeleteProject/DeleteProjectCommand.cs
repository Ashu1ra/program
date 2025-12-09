using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Commands.DeleteProject;

public record DeleteProjectCommand(long Id) : IRequest<Unit>;