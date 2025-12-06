using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.Domain.ValueObjects;

namespace Domain.Entities.Ref
{
    public class ListBoreholeIntervalType
    {
        public long Id { get; set; }
        public Mnemonic Mnemonic { get; set; }
        public Name Name { get; set; }
        public string? Metadata { get; set; } = "{ }";
        public string? Description { get; set; }
    }
}
