namespace DataAccessService.Domain.ValueObjects.Import
{
    public record SourceLink
    {
        public string Value { get; }

        private SourceLink(string value) 
        {
            Value = value;
        }

        public static SourceLink Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("SourceLink cannot be empty.");

            var lower = value.Trim().ToLowerInvariant();

            if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                throw new ArgumentException("SourceLink format is invalid.");

            return new SourceLink(lower);
        }

        public override string ToString() => Value;
    }
}
