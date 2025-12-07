namespace DataAccessService.Application.DTO.Geo;

public record CreateCityModelDto(
    long SiteId,
    string Format,
    byte[] FileData,
    string Metadata
);