namespace DataAccessService.Application.DTO.Igt;

public record BoreholeIntervalResponseDto(
    long Id,
    long LinkBorehole,
    DepthIntervalDto Interval,
    long LinkListBoreholeIntervalType,
    string? Metadata,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);