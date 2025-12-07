namespace DataAccessService.Application.DTO.Geo;

public record BimModelResponseDto(
    long Id,
    long SiteId,
    string Format,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt
);