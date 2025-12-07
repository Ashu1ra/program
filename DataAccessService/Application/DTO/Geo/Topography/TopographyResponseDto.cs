namespace DataAccessService.Application.DTO.Geo;

public record TopographyResponseDto(
    long Id,
    long SiteId,
    long DataSourceId,
    MultiPolygonDto Area,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);