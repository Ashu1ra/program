namespace DataAccessService.Application.Abstractions.Services
{
    public interface IAccessControlService
    {
        Task EnsureCanReadAsync(string schema, string table, long? objectId = null, CancellationToken ct = default);

        Task EnsureCanWriteAsync(string schema, string table, long? objectId = null, CancellationToken ct = default);

        Task EnsureCanDeleteAsync(string schema, string table, long? objectId = null, CancellationToken ct = default);
    }
}