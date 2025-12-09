using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Commands.DeleteRole;

public record DeleteRoleCommand(long Id) : IRequest<Unit>;