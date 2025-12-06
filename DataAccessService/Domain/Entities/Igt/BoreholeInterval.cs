using DataAccessService.Domain.ValueObjects.Igt;

namespace DataAccessService.Domain.Entities.Igt
{
    public class BoreholeInterval
    {
        public long Id { get; set; }
        public long LinkBorehole { get; set; } 
        public DepthInterval Interval { get; set; }
        public long LinkListBoreholeIntervalType { get; set; }
        public string? Metadata { get; set; } = "{ }";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
