namespace DataAccessService.Application.DTO.Test;

public record FieldTestResponseDto(
    long Id,
    long LinkBoreholeInterval,
    long LinkListTestType,
    string Results,
    DateTime TestDate,
    string? Metadata,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    long OwnerUserId
);
