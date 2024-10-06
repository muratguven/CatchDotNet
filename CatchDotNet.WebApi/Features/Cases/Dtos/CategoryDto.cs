namespace CatchDotNet.WebApi.Features.Cases.Dtos;

public record CategoryDto(Guid Id, Guid? ParentId, string Name, bool IsActive);