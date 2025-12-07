namespace DataAccessService.Application.DTO.Geo;

public record CreateSiteDto(
    long ProjectId,
    string Name,
    MultiPolygonDto Area,
    string? Description,
    long OwnerUserId
);