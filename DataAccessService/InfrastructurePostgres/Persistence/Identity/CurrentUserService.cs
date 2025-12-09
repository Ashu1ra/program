using DataAccessService.Application.Abstractions.Services;

namespace DataAccessService.InfrastructurePostgres.Identity;

public class CurrentUserService : ICurrentUserService
{
    public long UserId => 1;
    public bool IsAuthenticated => true;
}
