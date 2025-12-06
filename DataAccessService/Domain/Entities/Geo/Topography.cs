using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class Topography
    {
        public long Id { get; set; }
        public long LinkSite { get; set; }
        public long LinkDataSource { get; set; } 
        public MultiPolygon Area { get; set; }
        public string? Description { get; set; }
        public byte[] RasterFile { get; set; }
        public string? Metadata { get; set; } = "{ }";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}
