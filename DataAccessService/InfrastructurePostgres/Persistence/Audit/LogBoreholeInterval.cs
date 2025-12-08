namespace DataAccessService.InfrastructurePostgres.Entities.Audit
{
    public class LogBoreholeInterval
    {
        public long Id { get; set; }
        public long LinkBoreholeInterval { get; set; }
        public string? OldData { get; set; } = "{ }";
        public string OperationType { get; set; } = string.Empty;
        public long ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}