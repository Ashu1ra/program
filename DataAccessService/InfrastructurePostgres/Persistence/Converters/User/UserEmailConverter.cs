using DataAccessService.Domain.ValueObjects.Auth;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfrastructurePostgres.Persistence.Converters
{
    public class UserEmailConverter : ValueConverter<UserEmail, string>
    {
        public UserEmailConverter()
            : base(
                vo => vo.Value,
                str => UserEmail.Create(str)
            )
        { }
    }
}