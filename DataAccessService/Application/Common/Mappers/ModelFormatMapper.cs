using DataAccessService.Domain.ValueObjects.Geo;

namespace DataAccessService.Application.Common.Mappers;

public static class ModelFormatMapper
{
    public static ModelFormat ToDomain(string value)
        => ModelFormat.Create(value);

    public static string ToDto(ModelFormat domain)
        => domain.Value;
}