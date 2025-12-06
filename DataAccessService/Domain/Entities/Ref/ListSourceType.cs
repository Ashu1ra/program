using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListSourceType : AggregateRoot<long>
    {
        public Mnemonic Mnemonic { get; private set; }
        public Name Name { get; private set; }
        public string? Description { get; private set; }

        private ListSourceType() { }

        public static ListSourceType Create(Mnemonic mnemonic, Name name, string? description = null)
            => new ListSourceType
            {
                Mnemonic = mnemonic,
                Name = name,
                Description = description
            };

        public void Rename(Name name) => Name = name;

        public void UpdateDescription(string? description) => Description = description;
    }
}