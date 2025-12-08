using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;

namespace DataAccessService.Domain.Entities.Import
{
    public class DataSource : AggregateRoot<long>
    {
        public Name Name { get; private set; }
        public long LinkListSourceType { get; private set; }
        public SourceLink SourceLink { get; private set; }
        public string? Description { get; private set; } = string.Empty;
        public long OwnerUserId { get; private set; }

        private DataSource() { }

        public static DataSource Create(Name name, long typeId, long ownerUserId, SourceLink link, string? description)
            => new DataSource
            {
                Name = name,
                LinkListSourceType = typeId,
                SourceLink = link,
                Description = description,
                OwnerUserId = ownerUserId
            };

        public void UpdateDescription(string? description) => Description = description;
    }
}
