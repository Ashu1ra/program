using DataAccessService.Domain.Entities.Auth;
using DataAccessService.Application.Abstractions;

namespace DataAccessService.Application.Interfaces.Auth;

public interface IUserAccountRepository : IRepository<UserAccount>
{
    Task<UserAccount?> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
}