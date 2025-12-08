using DataAccessService.Domain.ValueObjects.Igt;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class DepthIntervalConverter : ValueConverter<DepthInterval, string>
    {
        public DepthIntervalConverter()
            : base(
                vo => Serialize(vo),
                json => Deserialize(json)
            )
        { }

        private static string Serialize(DepthInterval interval)
        {
            return JsonSerializer.Serialize(new
            {
                from = interval.From,
                to = interval.To
            });
        }

        private static DepthInterval Deserialize(string json)
        {
            var dto = JsonSerializer.Deserialize<DepthIntervalDto>(json)
                      ?? throw new InvalidOperationException("Invalid DepthInterval JSON.");

            return DepthInterval.Create(dto.from, dto.to);
        }

        private record DepthIntervalDto(double from, double to);
    }
}