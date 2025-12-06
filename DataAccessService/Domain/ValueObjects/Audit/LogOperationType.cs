namespace DataAccessService.Domain.ValueObjects.Audit
{
    public record LogOperationType
    {
        public string Value { get; }

        private static readonly string[] AllowedLogOperationTypes =
        {
            "INSERT", "UPDATE", "DELETE"
        };

        private LogOperationType(string value)
        {
            Value = value;
        }

        public static LogOperationType Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("LogOperationType name cannot be empty.");

            var lower = value.Trim().ToLowerInvariant();

            if (Array.IndexOf(AllowedLogOperationTypes, lower) < 0)
                throw new ArgumentException($"LogOperationType '{value}' is not allowed.");

            return new LogOperationType(lower);
        }

        public override string ToString() => Value;
    }
}
