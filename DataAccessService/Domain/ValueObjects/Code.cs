namespace DataAccessService.Domain.ValueObjects
{
    public record Code
    {
        public string Value { get; }

        private Code(string value) 
        {
            Value = value;
        }

        public static Code Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Code cannot be empty.");

            var lower = value.Trim().ToLowerInvariant();

            return new Code(lower);
        }

        public override string ToString() => Value;
    }
}
