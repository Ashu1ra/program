using DataAccessService.Domain.ValueObjects.Auth;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfrastructurePostgres.Persistence.Converters
{
    public class FullNameConverter : ValueConverter<FullName, string>
    {
        public FullNameConverter()
            : base(
                vo => vo.Value,
                str => FullName.Create(str)
            )
        { }
    }
}