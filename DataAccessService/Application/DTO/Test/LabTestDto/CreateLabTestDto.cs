namespace DataAccessService.Application.DTO.Test;

public record CreateLabTestDto(
    long SampleId,
    long TestTypeId,
    string Results,
    DateTime TestDate,
    string Metadata,
    long OwnerUserId
);