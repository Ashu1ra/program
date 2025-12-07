namespace DataAccessService.Application.DTO.Ref;

public record CreateListFileFormatDto(
    string Mnemonic,
    string Name,
    string Metadata,
    string? Description
);