using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Site : AggregateRoot<long>
    {
        public long LinkProject { get; private set; }
        public Name Name { get; set; }
        public Polygon Area { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private Site() { }

        public static Site Create(long LinkProject, Name name, Polygon area, long ownerUserId)
            => new Site
            {
                LinkProject = LinkProject,
                Name = name,
                Area = area,
                OwnerUserId = ownerUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

        public void UpdateName(Name name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateArea(Polygon area)
        {
            Area = area;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}