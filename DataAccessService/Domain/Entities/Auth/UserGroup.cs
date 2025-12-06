using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Auth
{
    public class UserGroup : Entity<long>
    {
        public long LinkUserAccount { get; private set; }
        public long LinkGroupList { get; private set; }

        private UserGroup() { } 

        private UserGroup(long userId, long groupId)
        {
            LinkUserAccount = userId;
            LinkGroupList = groupId;
        }

        public static UserGroup Create(long userId, long groupId)
            => new UserGroup(userId, groupId);
    }
}