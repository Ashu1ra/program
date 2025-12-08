using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Auth
{
    public class UserRole : Entity<long>
    {
        public long LinkUserAccount { get; private set; }
        public long LinkRoleList { get; private set; }

        private UserRole() { }

        private UserRole(long userId, long roleId)
        {
            LinkUserAccount = userId;
            LinkRoleList = roleId;
        }

        public static UserRole Create(long userId, long roleId)
            => new UserRole(userId, roleId);
    }
}