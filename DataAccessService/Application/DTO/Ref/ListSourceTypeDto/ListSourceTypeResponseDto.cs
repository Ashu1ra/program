namespace DataAccessService.Application.DTO.Ref;

public record ListSourceTypeResponseDto(
    long Id,
    string Mnemonic,
    string Name,
    string? Description
);