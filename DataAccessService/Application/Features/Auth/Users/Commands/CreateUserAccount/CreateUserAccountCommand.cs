using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Commands.CreateUserAccount;

public record CreateUserAccountCommand(CreateUserAccountDto Dto) : IRequest<long>;
