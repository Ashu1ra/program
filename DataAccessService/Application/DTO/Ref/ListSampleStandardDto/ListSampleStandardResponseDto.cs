namespace DataAccessService.Application.DTO.Ref;

public record ListSampleStandardResponseDto(
    long Id,
    string Mnemonic,
    string Name,
    string? Description
);