namespace CatchDotNet.WebApi;

public record CustomerDetailDto
{
    public Guid CustomerId { get; init; }
    public string DetailKey { get; init; }

    public string DetailValue { get; init; }
}
