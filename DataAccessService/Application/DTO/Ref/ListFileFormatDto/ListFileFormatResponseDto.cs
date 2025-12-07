namespace DataAccessService.Application.DTO.Ref;

public record ListFileFormatResponseDto(
    long Id,
    string Mnemonic,
    string Name,
    string Metadata,
    string? Description
);