using DataAccessService.Domain.ValueObjects.Auth;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfrastructurePostgres.Persistence.Converters
{
    public class UserLoginConverter : ValueConverter<UserLogin, string>
    {
        public UserLoginConverter()
            : base(
                vo => vo.Value,
                str => UserLogin.Create(str)
            )
        { }
    }
}