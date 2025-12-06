using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Project : AggregateRoot<long>
    {
        public long LinkListRegion { get; private set; } 
        public Name Name { get; private set; }
        public long LinkDataSource { get; private set; }
        public PointZ CenterLocation { get; private set; }
        public MultiPolygon Area { get; private set; }
        public DateTime DateStart { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private Project() { }

        public static Project Create(long linkListRegion, Name name, long linkDataSource, PointZ centerLocation, MultiPolygon area, long ownerUserId)
            => new Project
            {
                LinkListRegion = linkListRegion,
                Name = name,
                LinkDataSource = linkDataSource,
                CenterLocation = centerLocation,
                Area = area,
                DateStart = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                OwnerUserId = ownerUserId
            };

        public void UpdateArea(MultiPolygon area)
        {
            Area = area;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateCenter(PointZ centerLocation)
        {
            CenterLocation = centerLocation;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
