using DataAccessService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class CodeConverter : ValueConverter<Code, string>
    {
        public CodeConverter()
            : base(
                vo => vo.Value,
                str => Code.Create(str)
            )
        { }
    }
}