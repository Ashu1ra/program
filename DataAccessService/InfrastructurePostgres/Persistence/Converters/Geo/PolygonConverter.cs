using DataAccessService.Domain.ValueObjects.Geo;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class PolygonConverter : ValueConverter<Polygon, string>
    {
        public PolygonConverter()
            : base(
                vo => vo.ToString(),
                str => Parse(str)
            )
        { }

        private static Polygon Parse(string wkt)
        {
            var cleaned = wkt
                .Replace("POLYGON Z((", "")
                .Replace("))", "")
                .Trim();

            var pointStrings = cleaned.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var points = pointStrings
                .Select(p =>
                {
                    var nums = p.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    return PointZ.Create(
                        double.Parse(nums[0]),
                        double.Parse(nums[1]),
                        double.Parse(nums[2])
                    );
                })
                .ToList();

            return Polygon.Create(points);
        }
    }
}