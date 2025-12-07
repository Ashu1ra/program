namespace DataAccessService.Application.DTO.Igt;

public record SampleResponseDto(
    long Id,
    long IntervalId,
    string Number,
    double Depth,
    double DepthFrom,
    double DepthTo,
    long StandardId,
    string Metadata,
    string? Description,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);