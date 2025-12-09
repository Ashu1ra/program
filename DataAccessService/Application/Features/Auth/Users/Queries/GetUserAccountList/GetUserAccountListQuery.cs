using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Queries.GetUserAccountList;

public record GetUserAccountListQuery() : IRequest<IReadOnlyList<UserAccountResponseDto>>;