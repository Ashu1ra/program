using DataAccessService.Domain.ValueObjects.Audit;

namespace DataAccessService.Domain.Entities.Audit
{
    public class LogSample
    {
        public long Id { get; set; }
        public long LinkSample { get; set; }
        public string? OldData { get; set; } = "{ }";
        public LogOperationType OperationType { get; set; }
        public long ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}
