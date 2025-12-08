using DataAccessService.Domain.ValueObjects.Geo;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class PointZConverter : ValueConverter<PointZ, string>
    {
        public PointZConverter()
            : base(
                vo => vo.ToString(),
                str => Parse(str)
            )
        { }

        private static PointZ Parse(string wkt)
        {
            var cleaned = wkt.Replace("POINT Z(", "").Replace(")", "");
            var parts = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return PointZ.Create(
                double.Parse(parts[0]),
                double.Parse(parts[1]),
                double.Parse(parts[2]));
        }
    }
}