using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.Domain.ValueObjects;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListRegion
    {
        public long Id { get; set; }
        public Mnemonic Mnemonic { get; set; }
        public Code Code { get; set; }
        public Name Name { get; set; }
    }
}