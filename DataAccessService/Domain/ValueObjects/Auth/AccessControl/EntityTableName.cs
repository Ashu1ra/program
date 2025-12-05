using System;

namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record EntityTableName
    {
        public string Value { get; }

        private EntityTableName(string value)
        {
            Value = value;
        }

        public static EntityTableName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Entity table name cannot be empty.");

            return new EntityTableName(value.Trim());
        }

        public override string ToString() => Value;
    }
}