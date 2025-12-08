namespace DataAccessService.Application.Abstractions.Services
{
    public interface ICurrentUserService
    {
        long UserId { get; }
        bool IsAuthenticated { get; }
    }
}