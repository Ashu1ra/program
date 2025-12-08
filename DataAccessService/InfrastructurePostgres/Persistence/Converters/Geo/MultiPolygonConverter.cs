using DataAccessService.Domain.ValueObjects.Geo;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class MultiPolygonConverter : ValueConverter<MultiPolygon, string>
    {
        public MultiPolygonConverter()
            : base(
                vo => vo.ToString(),
                str => Parse(str)
            )
        { }

        private static MultiPolygon Parse(string wkt)
        {
            throw new NotImplementedException("MultiPolygon WKT → VO parsing is not implemented yet.");
        }
    }
}