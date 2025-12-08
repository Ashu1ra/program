using DataAccessService.Domain.ValueObjects.Import;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class SourceLinkConverter : ValueConverter<SourceLink, string>
    {
        public SourceLinkConverter()
            : base(
                vo => vo.Value,
                str => SourceLink.Create(str)
            )
        { }
    }
}