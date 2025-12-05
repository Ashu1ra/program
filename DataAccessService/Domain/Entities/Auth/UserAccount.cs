using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.Entities.Auth
{
    public class UserAccount
    {
        public long Id { get; set; }
        public UserLogin Login { get; set; }
        public UserEmail Email { get; set; }
        public PasswordHash PasswordHash { get; set; }
        public FullName FullName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Metadata { get; private set; } = "{  }";
    }
}