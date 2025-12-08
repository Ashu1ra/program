using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Auth
{
    public class RoleList : AggregateRoot<long>
    {
        public long Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public static RoleList Create(string name, string? description = null)
        => new RoleList { Name = name, Description = description };

        public void Rename(string name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
    }
}