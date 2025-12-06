using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;

namespace DataAccessService.Domain.Entities.Auth
{
    public class RoleList : AggregateRoot<long>
    {
        public long Id { get; private set; }
        public Name Name { get; private set; }
        public string? Description { get; private set; }

        public static RoleList Create(Name name, string? description = null)
        => new RoleList { Name = name, Description = description };

        public void Rename(Name name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
    }
}