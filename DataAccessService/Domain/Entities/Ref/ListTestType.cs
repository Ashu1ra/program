using DataAccessService.Domain.Common;
using DataAccessService.Domain.ValueObjects;
using DataAccessService.Domain.ValueObjects.Ref;

namespace DataAccessService.Domain.Entities.Ref
{
    public class ListTestType : AggregateRoot<long>
    {
        public Mnemonic Mnemonic { get; private set; }
        public Code Code { get; private set; }
        public Name Name { get; private set; }
        public TestCategory Category { get; private set; }
        public string? Description { get; private set; }

        private ListTestType() { }

        public static ListTestType Create(Mnemonic mnemonic, Code code, Name name, TestCategory category, string? description = null)
            => new ListTestType
            {
                Mnemonic = mnemonic,
                Code = code,
                Name = name,
                Category = category,
                Description = description
            };

        public void Rename(Name name) => Name = name;
        public void UpdateCode(Code code) => Code = code;
        public void UpdateCategory(TestCategory category) => Category = category;
        public void UpdateDescription(string? desc) => Description = desc;
    }
}