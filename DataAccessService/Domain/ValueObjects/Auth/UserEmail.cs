using System;
using System.Text.RegularExpressions;

namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record UserEmail
    {
        public string Value { get; }

        private UserEmail(string value)
        {
            Value = value;
        }

        public static UserEmail Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            value = value.Trim().ToLowerInvariant();

            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email format is invalid.");

            return new UserEmail(value);
        }

        public override string ToString() => Value;
    }
}