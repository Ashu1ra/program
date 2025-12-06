using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Topography : AggregateRoot<long>
    {
        public long LinkSite { get; private set; }
        public long LinkDataSource { get; private set; } 
        public MultiPolygon Area { get; private set; }
        public string? Description { get; private set; }
        public byte[] RasterFile { get; private set; }
        public string? Metadata { get; private set; } = "{ }";
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public long OwnerUserId { get; private set; }

        private Topography() { }

        public static Topography Create(
            long siteId, long dataSourceId, MultiPolygon area, byte[] raster, string metadata, long owner)
        {
            return new Topography
            {
                LinkSite = siteId,
                LinkDataSource = dataSourceId,
                Area = area,
                RasterFile = raster,
                Metadata = metadata,
                OwnerUserId = owner,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateArea(MultiPolygon area)
        {
            Area = area;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ReplaceRaster(byte[] newRaster)
        {
            RasterFile = newRaster;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateMetadata(string metadata)
        {
            Metadata = metadata;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}