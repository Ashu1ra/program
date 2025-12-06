using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListBoreholeType : AggregateRoot<long>
    {
        public Mnemonic Mnemonic { get; private set; }
        public Name Name { get; private set; }
        public string? Description { get; private set; }

        private ListBoreholeType() { }

        public static ListBoreholeType Create(Mnemonic mnemonic, Name name, string? description = null)
            => new ListBoreholeType
            {
                Mnemonic = mnemonic,
                Name = name,
                Description = description
            };

        public void Rename(Name name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
    }
}