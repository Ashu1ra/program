using DataAccessService.Domain.ValueObjects.Audit;
using DataAccessService.Domain.ValueObjects.Ref;

namespace DataAccessService.Domain.Entities.Audit
{
    public class LogTest
    {
        public long Id { get; set; }
        public TestCategory TestType { get; set; }
        public long LinkTest { get; set; }
        public string? OldData { get; set; } = "{ }";
        public LogOperationType OperationType { get; set; }
        public long ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}
