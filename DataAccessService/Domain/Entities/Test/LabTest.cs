namespace DataAccessService.Domain.Entities.Test
{
    public class LabTest
    {
        public long Id { get; set; }
        public long LinkSampl { get; set; }
        public long LinkListTestType { get; set; }
        public string? Results { get; set; } = "{ }";
        public DateTime TestDate { get; set; }
        public string? Metadata { get; set; } = "{ }";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
