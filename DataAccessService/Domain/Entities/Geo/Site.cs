using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Site
    {
        public long Id { get; set; }
        public long LinkProject { get; set; }
        public Name Name { get; set; }
        public MultiPolygon Area { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
