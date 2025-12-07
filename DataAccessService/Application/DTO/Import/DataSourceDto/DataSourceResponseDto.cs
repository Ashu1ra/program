namespace DataAccessService.Application.DTO.Import;

public record DataSourceResponseDto(
    long Id,
    string Name,
    long SourceTypeId,
    string? SourceLink,
    string? Description,
    long OwnerUserId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);