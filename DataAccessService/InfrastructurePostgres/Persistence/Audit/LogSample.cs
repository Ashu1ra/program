namespace DataAccessService.InfrastructurePostgres.Entities.Audit
{
    public class LogSample
    {
        public long Id { get; set; }
        public long LinkSample { get; set; }
        public string? OldData { get; set; } = "{ }";
        public string OperationType { get; set; } = string.Empty;
        public long ChangedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}