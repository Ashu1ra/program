namespace DataAccessService.Domain.Entities.Import
{
    public class RawFile_EntityLink
    {
        public long Id { get; set; }
        public long LinkRawFile { get; set; }
        public string EntitySchema { get; set; } = string.Empty;
        public string EntityName { get; set; } = string.Empty;
        public long ObjectId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
