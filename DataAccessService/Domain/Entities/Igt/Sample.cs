using DataAccessService.Domain.ValueObjects.Igt;
using DataAccessService.Domain.ValueObjects;

namespace DataAccessService.Domain.Entities.Igt
{
    public class Sample
    {
        public long Id { get; set; }
        public long LinkBoreholeInterval { get; set; } 
        public Code Number { get; set; }
        public DepthInterval Interval { get; set; }
        public long LinkListSampleStandard { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
