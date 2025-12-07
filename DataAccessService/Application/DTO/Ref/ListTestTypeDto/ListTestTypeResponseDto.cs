namespace DataAccessService.Application.DTO.Ref;

public record ListTestTypeResponseDto(
    long Id,
    string Mnemonic,
    string Code,
    string Name,
    string Category,
    string? Description
);