namespace DataAccessService.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; }

        private Name(string value)
        {
            Value = value;
        }

        public static Name Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            var cleaned = value.Trim();

            return new Name(cleaned);
        }

        public override string ToString() => Value;
    }
}