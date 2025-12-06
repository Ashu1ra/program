using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.Domain.ValueObjects;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListTestType
    {
        public long Id { get; set; }
        public Mnemonic Mnemonic { get; set; }
        public Code Code { get; set; }
        public Name Name { get; set; }
        public TestCategory Category { get; set; }
        public string? Description { get; set; }
    }
}