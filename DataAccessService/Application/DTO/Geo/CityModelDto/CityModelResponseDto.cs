namespace DataAccessService.Application.DTO.Geo;

public record CityModelResponseDto(
    long Id,
    long SiteId,
    string Format,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt
);