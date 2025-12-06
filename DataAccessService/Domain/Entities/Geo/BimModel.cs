using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class BimModel : AggregateRoot<long>
    {
        public long LinkSite { get; private set; }
        public ModelFormat Format { get; private set; }
        public MultiPolygon Area { get; private set; } 
        public byte[] FileData { get; private set; } 
        public string? Metadata { get; private set; } 
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private BimModel() { }

        public static BimModel Create(
            long siteId, ModelFormat format, byte[] data, string metadata)
        {
            return new BimModel
            {
                LinkSite = siteId,
                Format = format,
                FileData = data,
                Metadata = metadata,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void ReplaceFile(byte[] newData)
        {
            FileData = newData;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateMetadata(string metadata)
        {
            Metadata = metadata;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateFormat(ModelFormat format)
        {
            Format = format;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}