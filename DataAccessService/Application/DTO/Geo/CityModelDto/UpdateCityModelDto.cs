namespace DataAccessService.Application.DTO.Geo;

public record UpdateCityModelDto(
    string? Format,
    byte[]? FileData,
    string? Metadata
);