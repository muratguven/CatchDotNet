namespace CatchDotNet.API.ApplicationService.Customers.Dtos
{
    public record class CreateCustomerDto
    {
        public required string Name { get;  init; }
        public required string SurName { get;  init; }

        public required string PhoneNumber { get; init; }
    }
}
