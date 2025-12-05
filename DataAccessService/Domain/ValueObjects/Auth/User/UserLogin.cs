using System.Text.RegularExpressions;

namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record UserLogin
    {
        public string Value { get; }

        private UserLogin(string value)
        {
            Value = value;
        }

        public static UserLogin Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentException("Login cannot be empty.");

            var normalized = value.Trim().ToLowerInvariant();

            if (!Regex.IsMatch(normalized, @"^[a-z0-9_.-]{3,50}$"))
                throw new ArgumentException("Login has invalid characters or length.");

            return new UserLogin(normalized);
        }

        public override string ToString() => Value;
    }
}