namespace CatchDotNet.WebApi.Features.Cases.Dtos;

public record CaseDto(
    Guid Id,
    Guid CustomerId,
    string Name,
    string Surname,
    string PhoneNumber,
    Guid CategoryId,
    Guid StatusId,
    CaseDto Category,
    StatusDto Status);