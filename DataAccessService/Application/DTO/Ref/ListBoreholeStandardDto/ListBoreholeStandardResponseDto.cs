namespace DataAccessService.Application.DTO.Ref;

public record ListBoreholeStandardResponseDto(
    long Id,
    string Mnemonic,
    string Name,
    string? Description
);