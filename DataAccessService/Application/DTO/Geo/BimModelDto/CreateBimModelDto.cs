namespace DataAccessService.Application.DTO.Geo;

public record CreateBimModelDto(
    long SiteId,
    string Format,
    byte[] FileData,
    string Metadata
);