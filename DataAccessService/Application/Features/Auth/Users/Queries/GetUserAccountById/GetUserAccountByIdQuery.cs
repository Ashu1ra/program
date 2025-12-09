using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Queries.GetUserAccountById;

public record GetUserAccountByIdQuery(long Id) : IRequest<UserAccountResponseDto>;