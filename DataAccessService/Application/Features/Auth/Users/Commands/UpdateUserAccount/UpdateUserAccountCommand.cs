using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.DTO.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Commands.UpdateUserAccount;

public record UpdateUserAccountCommand(long Id, UpdateUserAccountDto Dto)
    : IRequest<Unit>;