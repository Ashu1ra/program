using System;

namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record EntitySchemaName
    {
        public string Value { get; }

        private static readonly string[] AllowedSchemas =
        {
            "ref", "import", "geo", "igt", "test", "audit", "auth"
        };

        private EntitySchemaName(string value)
        {
            Value = value;
        }

        public static EntitySchemaName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Schema name cannot be empty.");

            var lower = value.Trim().ToLowerInvariant();

            if (Array.IndexOf(AllowedSchemas, lower) < 0)
                throw new ArgumentException($"Schema '{value}' is not allowed.");

            return new EntitySchemaName(lower);
        }

        public override string ToString() => Value;
    }
}