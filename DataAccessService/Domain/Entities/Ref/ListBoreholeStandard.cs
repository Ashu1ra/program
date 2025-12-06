using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.Domain.ValueObjects;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListBoreholeStandard
    {
        public long Id { get; set; }
        public Mnemonic Mnemonic { get; set; }
        public Name Name { get; set; }
        public string? Description { get; set; }
    }
}