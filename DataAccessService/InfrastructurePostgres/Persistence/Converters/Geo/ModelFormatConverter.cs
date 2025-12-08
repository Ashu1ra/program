using DataAccessService.Domain.ValueObjects.Geo;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class ModelFormatConverter : ValueConverter<ModelFormat, string>
    {
        public ModelFormatConverter()
            : base(
                vo => vo.Value,
                str => ModelFormat.Create(str) 
            )
        { }
    }
}