using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessService.Domain.ValueObjects.Geo
{
    public record PointZ
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        private PointZ(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static PointZ Create(double x, double y, double z)
        {
            if (x < -180 || x > 180)
                throw new ArgumentOutOfRangeException(nameof(x), "Longitude must be between -180 and 180.");

            if (y < -90 || y > 90)
                throw new ArgumentOutOfRangeException(nameof(y), "Latitude must be between -90 and 90.");

            return new PointZ(x, y, z);
        }

        public override string ToString() => $"POINT Z({X} {Y} {Z})";
    }
}