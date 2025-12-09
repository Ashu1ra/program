using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Queries.GetRoleById;

public record GetRoleByIdQuery(long Id) : IRequest<RoleListResponseDto>;