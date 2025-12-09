using DataAccessService.Application.DTO.Geo;

namespace DataAccessService.Application.DTO.Igt;

public record UpdateBoreholeDto(
    double? DepthMax,
    DateTime? DateEnd,
    string? Metadata
);