namespace DataAccessService.Application.DTO.Igt;

public record CreateSampleDto(
    long IntervalId,
    string Number,
    double Depth,
    double DepthFrom,
    double DepthTo,
    long StandardId,
    string Metadata,
    string? Description,
    long OwnerUserId
);