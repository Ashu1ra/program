using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Site : AggregateRoot<long>
    {
        public long LinkProject { get; private set; }
        public Name Name { get; set; }
        public MultiPolygon Area { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private Site() { }

        public static Site Create(long LinkProject, Name name, MultiPolygon area, long ownerUserId)
            => new Site
            {
                LinkProject = LinkProject,
                Name = name,
                Area = area,
                OwnerUserId = ownerUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

        public void UpdateArea(MultiPolygon area)
        {
            Area = area;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
