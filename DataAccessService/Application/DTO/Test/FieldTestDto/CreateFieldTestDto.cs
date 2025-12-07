namespace DataAccessService.Application.DTO.Test;

public record CreateFieldTestDto(
    long IntervalId,
    long TestTypeId,
    string Results,
    DateTime TestDate,
    string Metadata,
    long OwnerUserId
);