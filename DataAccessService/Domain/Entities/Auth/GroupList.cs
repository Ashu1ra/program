using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.Entities.Auth
{
    public class GroupList
    {
        public long Id { get; set; }
        public GroupName Name { get; set; }
        public string? Description { get; set; }
    }
}