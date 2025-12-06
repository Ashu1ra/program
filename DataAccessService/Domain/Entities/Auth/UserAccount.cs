using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.Entities.Auth
{
    public class UserAccount : AggregateRoot<long>
    {
        public UserLogin Login { get; private set; }
        public UserEmail Email { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public FullName FullName { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public string Metadata { get; private set; } = "{  }";

        private UserAccount() { }

        public static UserAccount Create(UserLogin login, UserEmail email, PasswordHash password, FullName fullName, string metadata = "{}")
        {
            return new UserAccount
            {
                Login = login,
                Email = email,
                PasswordHash = password,
                FullName = fullName,
                Metadata = metadata,
                CreatedAt = DateTime.UtcNow,
                LastLogin = DateTime.UtcNow
            };
        }

        public void ChangeEmail(UserEmail email) => Email = email;
        public void ChangePassword(PasswordHash hash) => PasswordHash = hash;
        public void UpdateFullName(FullName fullName) => FullName = fullName;
        public void TouchLastLogin() => LastLogin = DateTime.UtcNow;
        public void UpdateMetadata(string metadata) => Metadata = metadata;

        public UserRole AssignRole(long roleId)
        {
            return UserRole.Create(Id, roleId);
        }
        public UserGroup AddToGroup(long groupId)
        {
            return UserGroup.Create(Id, groupId);
        }
        public UserRole RemoveRole(long roleId)
        {
            return UserRole.Create(Id, roleId);
        }
        public UserGroup RemoveGroup(long groupId)
        {
            return UserGroup.Create(Id, groupId);
        }
    }
}