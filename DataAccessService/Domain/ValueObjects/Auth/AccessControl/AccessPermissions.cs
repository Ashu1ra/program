namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record AccessPermissions
    {
        public bool CanRead { get; }
        public bool CanWrite { get; }
        public bool CanDelete { get; }

        private AccessPermissions(bool canRead, bool canWrite, bool canDelete)
        {
            CanRead = canRead;
            CanWrite = canWrite;
            CanDelete = canDelete;
        }

        public static AccessPermissions Create(bool read, bool write, bool delete)
            => new(read, write, delete);
    }
}