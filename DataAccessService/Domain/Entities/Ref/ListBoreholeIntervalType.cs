using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListBoreholeIntervalType : AggregateRoot<long>
    {
        public Mnemonic Mnemonic { get; private set; }
        public Name Name { get; private set; }
        public string? Metadata { get; private set; } = "{ }";
        public string? Description { get; private set; }

        private ListBoreholeIntervalType() { }

        public static ListBoreholeIntervalType Create(Mnemonic mnemonic, Name name, string metadata = "{}", string? description = null)
            => new ListBoreholeIntervalType
            {
                Mnemonic = mnemonic,
                Name = name,
                Metadata = metadata,
                Description = description
            };

        public void Rename(Name name) => Name = name;
        public void UpdateDescription(string? description) => Description = description;
        public void UpdateMetadata(string metadata) => Metadata = metadata;
    }
}
