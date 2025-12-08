using DataAccessService.Domain.ValueObjects.Ref;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class MnemonicConverter : ValueConverter<Mnemonic, string>
    {
        public MnemonicConverter()
            : base(
                vo => vo.Value,
                str => Mnemonic.Create(str)
            )
        { }
    }
}