using DataAccessService.Application.Abstractions.Persistence;
using DataAccessService.Application.DTO.Auth;
using DataAccessService.Application.Services.Security;
using DataAccessService.Domain.Entities.Auth;
using MediatR;

namespace DataAccessService.Application.Features.Auth.Users.Queries.GetUserAccountList;

public class GetUserAccountListHandler
    : IRequestHandler<GetUserAccountListQuery, IReadOnlyList<UserAccountResponseDto>>
{
    private readonly IReadOnlyRepository<UserAccount> _repo;
    private readonly AclGuard _acl;

    public GetUserAccountListHandler(
        IReadOnlyRepository<UserAccount> repo,
        AclGuard acl)
    {
        _repo = repo;
        _acl = acl;
    }

    public async Task<IReadOnlyList<UserAccountResponseDto>> Handle(
        GetUserAccountListQuery request,
        CancellationToken ct)
    {
        await _acl.RequireReadAsync("auth", "user_account", null, ct);

        var users = await _repo.GetAllAsync(ct);

        return users.Select(u => new UserAccountResponseDto(
            u.Id,
            u.Login.Value,
            u.Email.Value,
            u.FullName.Value,
            u.CreatedAt,
            u.LastLogin,
            u.Metadata
        )).ToList();
    }
}