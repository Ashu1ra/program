using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Borehole : AggregateRoot<long>
    {
        public long LinkSite { get; private set; }
        public PointZ Location { get; private set; }
        public long LinkListBoreholeType { get; private set; } 
        public double DepthMin { get; set; } 
        public double DepthMax { get; set; } 
        public long LinkListBoreholeStandard { get; private set; } 
        public DateTime DateStart { get; private set; } 
        public DateTime? DateEnd { get; private set; }
        public string? Metadata { get; private set; } = "{ }";
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private Borehole() { }

        public static Borehole Create(
            long site, PointZ location, long linkListBoreholeType, double dmin, double dmax, long linkListBoreholeStandard, DateTime dateStart, DateTime dateEnd, string metadata, long ownerUserId)
            => new Borehole
            {
                LinkSite = site,
                Location = location,
                LinkListBoreholeType = linkListBoreholeType,
                DepthMin = dmin,
                DepthMax = dmax,
                LinkListBoreholeStandard = linkListBoreholeStandard,
                DateStart = dateStart,
                DateEnd = dateEnd,
                Metadata = metadata,
                OwnerUserId = ownerUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

        public void UpdateMetadata(string metadata)
        {
            Metadata = metadata;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}