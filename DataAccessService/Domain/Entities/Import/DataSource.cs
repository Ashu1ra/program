using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;

namespace DataAccessService.Domain.Entities.Import
{
    public class DataSource : AggregateRoot<long>
    {
        public Name Name { get; set; }
        public long LinkListSourceType { get; set; }
        public SourceLink SourceLink { get; set; }
        public string? Description { get; set; } = string.Empty;
        public long OwnerUserId { get; set; }

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
