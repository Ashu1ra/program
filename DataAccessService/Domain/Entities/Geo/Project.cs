using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Project
    {
        public long Id { get; set; }
        public long LinkListRegion { get; set; } 
        public Name Name { get; set; }
        public long LinkDataSource { get; set; }
        public PointZ CenterLocation { get; set; }
        public MultiPolygon Area { get; set; }
        public DateTime DateStart { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
