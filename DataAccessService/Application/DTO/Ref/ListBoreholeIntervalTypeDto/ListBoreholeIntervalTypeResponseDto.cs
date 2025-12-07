namespace DataAccessService.Application.DTO.Ref;

public record ListBoreholeIntervalTypeResponseDto(
    long Id,
    string Mnemonic,
    string Name,
    string Metadata,
    string? Description
);