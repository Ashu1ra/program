namespace DataAccessService.Application.DTO.Geo;

public record BimModelResponseDto(
    long Id,
    long LinkSite,
    string Format,
    MultiPolygonDto Area,
    string? Metadata,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);