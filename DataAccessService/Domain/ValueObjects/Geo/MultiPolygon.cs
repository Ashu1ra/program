namespace DataAccessService.Domain.ValueObjects.Geo
{
    /// <summary>
    /// Domain Value Object representing a MultiPolygon with Z-coordinates.
    /// Structure:
    /// MultiPolygon
    ///   -> List of Polygons
    ///        -> List of Contours (first = outer, others = holes)
    ///             -> List of PointZ
    /// </summary>
    public sealed record MultiPolygon
    {
        /// <summary>
        /// Polygons -> Contours -> Points
        /// Polygons[i][0] = outer ring
        /// Polygons[i][1..N] = holes
        /// </summary>
        public IReadOnlyList<IReadOnlyList<IReadOnlyList<PointZ>>> Polygons { get; }

        private MultiPolygon(IReadOnlyList<IReadOnlyList<IReadOnlyList<PointZ>>> polygons)
        {
            Polygons = polygons;
        }

        public static MultiPolygon Create(IEnumerable<IEnumerable<IEnumerable<PointZ>>> polygons)
        {
            if (polygons is null)
                throw new ArgumentNullException(nameof(polygons));

            var polygonList = polygons.Select(poly =>
            {
                if (poly is null)
                    throw new ArgumentException("Polygon cannot be null.");

                var contours = poly.Select(contour =>
                {
                    if (contour is null)
                        throw new ArgumentException("Contour cannot be null.");

                    var pts = contour.ToList();
                    ValidateContour(pts);

                    pts = EnsureClosedRing(pts);

                    return (IReadOnlyList<PointZ>)pts;
                }).ToList();

                if (contours.Count == 0)
                    throw new ArgumentException("Polygon must contain at least one contour.");

                return (IReadOnlyList<IReadOnlyList<PointZ>>)contours;

            }).ToList();

            if (polygonList.Count == 0)
                throw new ArgumentException("MultiPolygon must contain at least one polygon.");

            return new MultiPolygon(polygonList);
        }

        private static void ValidateContour(IReadOnlyList<PointZ> points)
        {
            if (points.Count < 3)
                throw new ArgumentException("Contour must contain at least 3 unique points.");

            if (points.Count >= 4 && points.First().Equals(points.Last()))
                return;

            if (points.Count < 3)
                throw new ArgumentException("Contour must have at least 3 non-repeated points.");
        }

        private static List<PointZ> EnsureClosedRing(IReadOnlyList<PointZ> pts)
        {
            if (pts.First().Equals(pts.Last()))
                return pts.ToList();

            var closed = pts.ToList();
            closed.Add(pts.First());
            return closed;
        }

        public override string ToString()
        {
            var polygonsWkt = string.Join(", ",
                Polygons.Select(poly =>
                {
                    var rings = poly.Select(ring =>
                        "(" + string.Join(", ", ring.Select(pt => $"{pt.X} {pt.Y} {pt.Z}")) + ")"
                    );

                    return "(" + string.Join(", ", rings) + ")";
                })
            );

            return $"MULTIPOLYGON Z({polygonsWkt})";
        }
    }
}