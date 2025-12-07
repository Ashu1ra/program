namespace DataAccessService.Application.DTO.Igt;

using DataAccessService.Application.DTO.Geo;

public record UpdateBoreholeDto(
    PointZDto? Location,
    double? DepthMin,
    double? DepthMax,
    long? BoreholeTypeId,
    long? StandardId,
    DateTime? DateStart,
    DateTime? DateEnd,
    string? Metadata
);