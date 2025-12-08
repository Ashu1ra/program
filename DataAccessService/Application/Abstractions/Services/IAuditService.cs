namespace DataAccessService.Application.Abstractions.Services
{
    public interface IAuditService
    {
        Task WriteAuditEntryAsync(
            string table,
            long objectId,
            object? oldData,
            string operationType,
            CancellationToken ct = default);
    }
}
