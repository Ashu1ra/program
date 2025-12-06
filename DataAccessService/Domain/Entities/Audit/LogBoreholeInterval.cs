using DataAccessService.Domain.ValueObjects.Audit;

namespace DataAccessService.Domain.Entities.Audit
{
    public class LogBoreholeInterval
    {
        public long Id { get; set; }
        public long LinkBoreholeInterval { get; set; }
        public string? OldData { get; set; } = "{ }";
        public LogOperationType OperationType { get; set; }
        public long ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}
