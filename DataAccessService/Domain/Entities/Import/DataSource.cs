using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Import;

namespace DataAccessService.Domain.Entities.Import
{
    public class DataSource
    {
        public long Id { get; set; }
        public Name Name { get; set; }
        public long LinkListSourceType { get; set; }
        public SourceLink SourceLink { get; set; }
        public string? Description { get; set; } = string.Empty;
        public long OwnerUserId { get; set; }

    }
}
