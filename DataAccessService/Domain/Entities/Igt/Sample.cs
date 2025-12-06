using DataAccessService.Domain.ValueObjects.Igt;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Sample : AggregateRoot<long>
    {
        public long Id { get; set; }
        public long LinkBoreholeInterval { get; private set; } 
        public Code Number { get; private set; }
        public DepthInterval Interval { get; private set; }
        public long LinkListSampleStandard { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private Sample() { }

        public static Sample Create(
            long intervalId, Code number, DepthInterval interval, long standardId, string metadata, string? description, long owner)
        {
            return new Sample
            {
                LinkBoreholeInterval = intervalId,
                Number = number,
                Interval = interval,
                LinkListSampleStandard = standardId,
                Description = description,
                OwnerUserId = owner,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateDescription(string? desc)
        {
            Description = desc;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateInterval(DepthInterval interval)
        {
            Interval = interval;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}