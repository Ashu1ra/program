namespace DataAccessService.Domain.ValueObjects.Auth
{
    public record GroupName
    {
        public string Value { get; }

        private GroupName(string value)
        {
            Value = value;
        }

        public static GroupName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Group name cannot be empty.");

            return new GroupName(value.Trim());
        }

        public override string ToString() => Value;
    }
}