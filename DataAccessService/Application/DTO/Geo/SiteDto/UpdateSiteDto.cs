namespace DataAccessService.Application.DTO.Geo;

public record UpdateSiteDto(
    string Name,
    PolygonDto Area,
    string? Description
);