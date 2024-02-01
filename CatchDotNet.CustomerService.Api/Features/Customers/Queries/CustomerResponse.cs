namespace CatchDotNet.CustomerService.Api.Features.Customers.Queries
{
    public record CustomerResponse
    {
        public Guid Id { get; init; }
        public string NameSurname { get; init; }
        public string Email { get; init; }

        public string PhoneNumber { get; init; }
        public bool IsActive { get; init; }
    }
}
