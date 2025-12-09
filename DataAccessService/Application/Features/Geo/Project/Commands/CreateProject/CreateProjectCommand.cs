using DataAccessService.Application.DTO.Geo;
using MediatR;

namespace DataAccessService.Application.Features.Geo.Projects.Commands.CreateProject;

public record CreateProjectCommand(CreateProjectDto Dto)
    : IRequest<long>;