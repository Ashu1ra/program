namespace DataAccessService.Application.DTO.Ref;

public record ListBoreholeTypeResponseDto(
    long Id,
    string Mnemonic,
    string Name,
    string? Description
);