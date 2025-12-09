using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class CityModel : AggregateRoot<long>
    {
        public long LinkSite { get; private set; }
        public ModelFormat Format { get; private set; }
        public MultiPolygon Area { get; private set; }
        public byte[] FileData { get; private set; }
        public string? Metadata { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private CityModel() { }

        public static CityModel Create(long siteId, ModelFormat format, MultiPolygon area, byte[] fileData, string metadata)
        {
            return new CityModel
            {
                LinkSite = siteId,
                Format = format,
                Area = area,
                FileData = fileData,
                Metadata = metadata,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateArea(MultiPolygon area)
        {
            Area = area;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ReplaceFile(byte[] newFile)
        {
            FileData = newFile;
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