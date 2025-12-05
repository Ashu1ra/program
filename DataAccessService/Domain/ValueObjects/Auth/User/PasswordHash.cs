using System;

namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record PasswordHash
    {
        public string Value { get; }

        private PasswordHash(string value)
        {
            Value = value;
        }

        public static PasswordHash Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password hash cannot be empty.");

            if (value.Length < 40) // минимальный размер sha256/base64
                throw new ArgumentException("Password hash is too short.");

            return new PasswordHash(value);
        }

        public override string ToString() => Value;
    }
}