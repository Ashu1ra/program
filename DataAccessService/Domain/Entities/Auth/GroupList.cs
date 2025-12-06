using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;

namespace DataAccessService.Domain.Entities.Auth
{
    public class GroupList : AggregateRoot<long>
    {
        public Name Name { get; private set; }
        public string? Description { get; private set; }

        private GroupList() { }

        public static GroupList Create(Name name, string? description = null)
        => new GroupList { Name = name, Description = description };

        public void Rename(Name name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
    }
}