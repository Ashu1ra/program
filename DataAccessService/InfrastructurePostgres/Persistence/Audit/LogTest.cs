namespace DataAccessService.InfrastructurePostgres.Entities.Audit
{
    public class LogTest
    {
        public long Id { get; set; }
        public string TestType { get; set; } = string.Empty;
        public long LinkTest { get; set; }
        public string? OldData { get; set; } = "{ }";
        public string OperationType { get; set; } = string.Empty;
        public long ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}