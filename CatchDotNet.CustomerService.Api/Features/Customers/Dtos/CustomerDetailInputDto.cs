namespace CatchDotNet.CustomerService.Api.Features.Customers.Dtos;

public record CustomerDetailInputDto
{
    public CustomerDetailInputDto(Guid customerId,
                                  string detailKey,
                                  string detailValue)
    {
        CustomerId = customerId;
        DetailKey = detailKey;
        DetailValue = detailValue;
    }

    public Guid CustomerId { get; init; }
    public string DetailKey { get; init; }
    public string DetailValue { get; init; }
}
