using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Igt;

namespace DataAccessService.Domain.Entities.Igt
{
    public class BoreholeInterval : AggregateRoot<long>
    {
        public long LinkBorehole { get; private set; } 
        public DepthInterval Interval { get; private set; }
        public long LinkListBoreholeIntervalType { get; private set; }
        public string? Metadata { get; private set; } = "{ }";
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private BoreholeInterval() {}

    public static BoreholeInterval Create(long borehole, DepthInterval interval, long linkListBoreholeIntervalType, string metadata, long ownerUserId)
        => new BoreholeInterval
        {
            LinkBorehole = borehole,
            Interval = interval,
            LinkListBoreholeIntervalType = linkListBoreholeIntervalType,
            Metadata = metadata,
            OwnerUserId = ownerUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
}