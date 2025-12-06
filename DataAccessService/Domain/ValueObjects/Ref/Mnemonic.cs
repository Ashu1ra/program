namespace DataAccessService.Domain.ValueObjects.Ref
{
    public record Mnemonic
    {
        public string Value { get; }

        private Mnemonic(string  value)
        {
            Value = value;
        }

        public static Mnemonic Create(string value) 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Mnemonic cannot be empty.");

            var cleaned = value.Trim();

            return new Mnemonic(cleaned);
        }

        public override string ToString() => Value;
    }
}
