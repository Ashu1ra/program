using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Commands.DeleteUserAccount;

public record DeleteUserAccountCommand(long Id) : IRequest<Unit>;