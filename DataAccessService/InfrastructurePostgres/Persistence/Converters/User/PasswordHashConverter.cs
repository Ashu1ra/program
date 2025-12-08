using DataAccessService.Domain.ValueObjects.Auth;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfrastructurePostgres.Persistence.Converters
{
    public class PasswordHashConverter : ValueConverter<PasswordHash, string>
    {
        public PasswordHashConverter()
            : base(
                vo => vo.Value,
                str => PasswordHash.Create(str)
            )
        { }
    }
}