namespace DataAccessService.Domain.ValueObjects.Geo
{
    public record MultiPolygon
    {
        public IReadOnlyList<IReadOnlyList<PointZ>> Polygons { get; }

        private MultiPolygon(IReadOnlyList<IReadOnlyList<PointZ>> polygons)
        {
            Polygons = polygons;
        }

        public static MultiPolygon Create(IEnumerable<IEnumerable<PointZ>> polygons)
        {
            if (polygons == null)
                throw new ArgumentNullException(nameof(polygons));

            var polyList = polygons
                .Select(p =>
                {
                    var points = p?.ToList() ?? throw new ArgumentException("Polygon cannot be null.");
                    if (points.Count < 3)
                        throw new ArgumentException("Polygon must have at least 3 points.");
                    return (IReadOnlyList<PointZ>)points;
                })
                .ToList();

            if (!polyList.Any())
                throw new ArgumentException("MultiPolygon must contain at least one polygon.");

            return new MultiPolygon(polyList);
        }

        public override string ToString()
        {

            var polygonsWkt = string.Join(", ",
                Polygons.Select(p => "(" + string.Join(", ", p.Select(pt => $"{pt.X} {pt.Y} {pt.Z}")) + ")"));
            return $"MULTIPOLYGON Z({polygonsWkt})";
        }
    }
}
