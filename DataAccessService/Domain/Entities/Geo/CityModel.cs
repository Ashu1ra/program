using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Domain.Entities.Geo
{
    public class CityModel
    {
        public long Id { get; set; }
        public long LinkSite { get; set; }
        public ModelFormat Format { get; set; }
        public MultiPolygon Area { get; set; }
        public byte[] FileData { get; set; }
        public string? Metadata { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long OwnerUserId { get; set; }
    }
}