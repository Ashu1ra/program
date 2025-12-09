using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Commands.UpdateRole;

public record UpdateRoleCommand(long Id, UpdateRoleListDto Dto) : IRequest<Unit>;