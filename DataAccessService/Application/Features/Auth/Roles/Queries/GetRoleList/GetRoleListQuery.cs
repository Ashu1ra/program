using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Roles.Queries.GetRoleList;

public record GetRoleListQuery() : IRequest<IReadOnlyList<RoleListResponseDto>>;