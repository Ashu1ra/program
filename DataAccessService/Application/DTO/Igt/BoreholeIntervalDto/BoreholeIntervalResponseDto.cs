namespace DataAccessService.Application.DTO.Igt;

public record BoreholeIntervalResponseDto(
    long Id,
    long BoreholeId,
    double DepthFrom,
    double DepthTo,
    long IntervalTypeId,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);