namespace DataAccessService.Application.DTO.Ref;

public record UpdateListTestTypeDto(
    string? Code,
    string? Name,
    string? Category,
    string? Description
);