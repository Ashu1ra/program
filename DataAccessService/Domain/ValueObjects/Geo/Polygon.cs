using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessService.Domain.ValueObjects.Geo
{
    /// <summary>
    /// Simple polygon represented by one outer contour (ring) of PointZ.
    /// Polygon must contain at least 3 points + auto-closed ring.
    /// </summary>
    public sealed record Polygon
    {
        public IReadOnlyList<PointZ> Points { get; }

        private Polygon(IReadOnlyList<PointZ> points)
        {
            Points = points;
        }

        public static Polygon Create(IEnumerable<PointZ> points)
        {
            if (points is null)
                throw new ArgumentNullException(nameof(points));

            var pts = points.ToList();

            if (pts.Count < 3)
                throw new ArgumentException("Polygon must contain at least 3 points.");

            pts = EnsureClosedRing(pts);

            return new Polygon(pts);
        }

        private static List<PointZ> EnsureClosedRing(List<PointZ> pts)
        {
            var first = pts.First();
            var last = pts.Last();

            if (!first.Equals(last))
                pts.Add(first);

            return pts;
        }

        public override string ToString()
        {
            var inside = string.Join(", ",
                Points.Select(p => $"{p.X} {p.Y} {p.Z}")
            );

            return $"POLYGON Z(({inside}))";
        }
    }
}