using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Borehole
    {
        public long Id { get; set; }
        public long Link_site { get; set; }
        public PointZ Location { get; set; } = default!;
        public long LinkListBoreholeType { get; set; } 
        public double DepthMin { get; set; } 
        public double DepthMax { get; set; } 
        public long LinkListBoreholeStandard { get; set; } 
        public DateTime DateStart { get; set; } 
        public DateTime? DateEnd { get; set; }
        public string? Metadata { get; set; } = "{ }";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
