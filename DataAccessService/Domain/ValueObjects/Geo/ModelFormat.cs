using System;

namespace DataAccessService.Domain.ValueObjects.Geo
{
    public record ModelFormat
    {
        public string Value { get; }

        private static readonly string[] AllowedModelFormats =
        {
            "IFC", "3DTILES", "DWG", "DXF", "DGN"
        };

        private ModelFormat(string value)
        {
            Value = value;
        }

        public static ModelFormat Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ModelFormat name cannot be empty.");

            var upper = value.Trim().ToUpperInvariant();

            if (Array.IndexOf(AllowedModelFormats, upper) < 0)
                throw new ArgumentException($"ModelFormat '{value}' is not allowed.");

            return new ModelFormat(upper);
        }

        public override string ToString() => Value;
    }
}