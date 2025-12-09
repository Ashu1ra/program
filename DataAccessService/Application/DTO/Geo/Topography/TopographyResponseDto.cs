namespace DataAccessService.Application.DTO.Geo;

public record TopographyResponseDto(
    long Id,
    long LinkSite,
    long LinkDataSource,
    MultiPolygonDto Area,
    string? Description,
    string? Metadata,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);