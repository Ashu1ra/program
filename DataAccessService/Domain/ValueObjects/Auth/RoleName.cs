namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record RoleName
    {
        public string Value { get; }

        private RoleName(string value)
        {
            Value = value;
        }

        public static RoleName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Role name cannot be empty.");

            var normalized = value.Trim().ToUpperInvariant();

            return new RoleName(normalized);
        }

        public override string ToString() => Value;
    }
}
