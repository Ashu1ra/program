namespace DataAccessService.Application.Abstractions.Services
{
    public interface IAccessControlService
    {
        Task<bool> CanReadAsync(string schema, string table, long? objectId = null, CancellationToken cancellationToken = default);
        Task<bool> CanWriteAsync(string schema, string table, long? objectId = null, CancellationToken cancellationToken = default);
        Task<bool> CanDeleteAsync(string schema, string table, long? objectId = null, CancellationToken cancellationToken = default);
    }
}