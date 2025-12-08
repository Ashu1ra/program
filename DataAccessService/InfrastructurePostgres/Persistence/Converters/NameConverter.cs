using DataAccessService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class NameConverter : ValueConverter<Name, string>
    {
        public NameConverter()
            : base(
                vo => vo.Value,
                str => Name.Create(str)
            )
        { }
    }
}