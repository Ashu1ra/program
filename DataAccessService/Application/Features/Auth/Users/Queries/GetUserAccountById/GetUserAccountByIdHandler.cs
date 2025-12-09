using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.Common.Exceptions;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Queries.GetUserAccountById;

public class GetUserAccountByIdHandler
    : IRequestHandler<GetUserAccountByIdQuery, UserAccountResponseDto>
{
    private readonly IReadOnlyRepository<UserAccount> _repo;
    private readonly AclGuard _acl;

    public GetUserAccountByIdHandler(
        IReadOnlyRepository<UserAccount> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<UserAccountResponseDto> Handle(GetUserAccountByIdQuery request, CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "user_account", request.Id, ct);

        var user = await _repo.GetByIdAsync(request.Id, ct);
        if (user == null)
            throw new NotFoundException("User not found");

        return new UserAccountResponseDto(
            user.Id,
            user.Login.Value,
            user.Email.Value,
            user.FullName.Value,
            user.CreatedAt,
            user.LastLogin,
            user.Metadata
        );
    }
}
