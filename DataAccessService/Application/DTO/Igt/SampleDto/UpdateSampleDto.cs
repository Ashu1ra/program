namespace DataAccessService.Application.DTO.Igt;

public record UpdateSampleDto(
    double? Depth,
    double? DepthFrom,
    double? DepthTo,
    long? StandardId,
    string? Metadata,
    string? Description
);