using DataAccessService.Domain.ValueObjects.Ref;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.Common;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListRegion : AggregateRoot<long>
    {
        public Mnemonic Mnemonic { get; private set; }
        public Code Code { get; private set; }
        public Name Name { get; private set; }

        public static ListRegion Create(Mnemonic mnemonic, Code code, Name name)
        => new ListRegion
        {
            Mnemonic = mnemonic,
            Code = code,
            Name = name
        };

        public void UpdateMnemonic(Mnemonic mnemonic) => Mnemonic = mnemonic;
        public void UpdateCode(Code code) => Code = code;
        public void UpdateName(Name name) => Name = name;
    }
}