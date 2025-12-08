using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Auth
{
    public class GroupList : AggregateRoot<long>
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        private GroupList() { }

        public static GroupList Create(string name, string? description = null)
        => new GroupList { Name = name, Description = description };

        public void Rename(string name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
    }
}