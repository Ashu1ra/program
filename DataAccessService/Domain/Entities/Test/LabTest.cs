using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Test
{
    public class LabTest : AggregateRoot<long>
    {
        public long LinkSample { get; private set; }
        public long LinkListTestType { get; private set; }
        public string? Results { get; private set; } = "{ }";
        public DateTime TestDate { get; private set; }
        public string? Metadata { get; private set; } = "{ }";
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private LabTest() { }

        public static LabTest Create(long linkSampl, long linkListTestType, string results, DateTime TestDate, string metadata, long ownerUserId)
            => new LabTest
            {
                LinkSample = linkSampl,
                LinkListTestType = linkListTestType,
                Results = results,
                TestDate = TestDate,
                Metadata = metadata,
                OwnerUserId = ownerUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
    }
}
