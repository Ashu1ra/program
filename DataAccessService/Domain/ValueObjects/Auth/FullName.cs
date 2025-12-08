namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record FullName
    {
        public string Value { get; }

        private FullName(string value)
        {
            Value = value;
        }

        public static FullName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be empty.");

            var cleaned = value.Trim();

            if (cleaned.Length < 2)
                throw new ArgumentException("Full name is too short.");

            return new FullName(cleaned);
        }

        public override string ToString() => Value;
    }
}