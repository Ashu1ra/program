namespace DataAccessService.Application.DTO.Test;

public record FieldTestResponseDto(
    long Id,
    long IntervalId,
    long TestTypeId,
    string Results,
    DateTime TestDate,
    string Metadata,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    long OwnerUserId
);