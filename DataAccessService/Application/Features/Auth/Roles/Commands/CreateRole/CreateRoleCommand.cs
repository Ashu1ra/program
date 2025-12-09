using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Commands.CreateRole;

public record CreateRoleCommand(CreateRoleListDto Dto) : IRequest<long>;