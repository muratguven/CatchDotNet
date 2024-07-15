namespace CatchDotNet.WebApi;

public record CustomerWithDetailDto
{
    public Guid Id { get; init; }
    public string NameSurname { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public bool IsActive { get; init; }
    public List<CustomerDetailDto> Details { get; init; }

    public void AddRangeDetails(List<CustomerDetailDto> details)
    {
        if(details is not null && details.Count > 0)
        {
            Details.AddRange(details);
        }
        
    }
}
