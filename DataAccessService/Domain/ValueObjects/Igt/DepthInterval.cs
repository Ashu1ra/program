namespace DataAccessService.Domain.ValueObjects.Igt
{
    public record DepthInterval
    {
        public double From { get; }
        public double To { get; }

        private DepthInterval(double from, double to)
        {
            From = from;
            To = to;
        }

        public static DepthInterval Create(double from, double to)
        {
            if (from < 0)
                throw new ArgumentOutOfRangeException(nameof(from), "Depth cannot be negative.");
            if (to < 0)
                throw new ArgumentOutOfRangeException(nameof(to), "Depth cannot be negative.");
            if (from > to)
                throw new ArgumentException("From depth cannot be greater than To depth.");

            return new DepthInterval(from, to);
        }

        public double Length => To - From;

        public DepthInterval Update(double from, double to) => Create(from, to);

        public override string ToString() => $"DepthInterval [From={From}, To={To}, Length={Length}]";
    }
}
