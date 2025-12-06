using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListSampleStandard : AggregateRoot<long>
    {
        public Mnemonic Mnemonic { get; private set; }
        public Name Name { get; private set; }
        public string? Description { get; private set; }

        private ListSampleStandard() { }

        public static ListSampleStandard Create(Mnemonic mnemonic, Name name, string? description = null)
            => new ListSampleStandard
            {
                Mnemonic = mnemonic,
                Name = name,
                Description = description
            };

        public void Rename(Name name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
    }
}