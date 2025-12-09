using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Test
{
    public class FieldTest : AggregateRoot<long>
    {
        public long LinkBoreholeInterval { get; private set; } 
        public long LinkListTestType { get; private set; } 
        public string? Results { get; private set; } = "{ }";
        public DateTime TestDate { get; private set; }
        public string? Metadata { get; private set; } = "{ }";
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private FieldTest() { }

        public static FieldTest Create(long interval, long linkListTestType, string results, DateTime testDate, string metadata, long ownerUserId)
            => new FieldTest
            {
                LinkBoreholeInterval = interval,
                LinkListTestType = linkListTestType,
                Results = results,
                TestDate = testDate,
                Metadata = metadata,
                OwnerUserId = ownerUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

        public void UpdateResults(string results)
        {
            Results = results;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateMetadata(string metadata)
        {
            Metadata = metadata;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}