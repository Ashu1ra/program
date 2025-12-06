using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.ValueObjects.Ref
{
    public record TestCategory
    {
        public string Value { get; }

        private static readonly string[] AllowedCategorys =
        {
            "lab", "field"
        };

        private TestCategory(string value)
        {
            Value = value;
        }

        public static TestCategory Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("TestCategory name cannot be empty.");

            var lower = value.Trim().ToLowerInvariant();

            if (Array.IndexOf(AllowedCategorys, lower) < 0)
                throw new ArgumentException($"TestCategory '{value}' is not allowed.");

            return new TestCategory(lower);
        }

        public override string ToString() => Value;
    }
}
