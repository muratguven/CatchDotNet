namespace CatchDotNet.CustomerService.Api.Features.Customers.Dtos
{
    public record CustomerWithDetailDto
    {
        public Guid Id { get; init; }
        public string NameSurname { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public bool IsActive { get; init; }
        public List<CustomerDetailDto> Details { get; init; }
    }
}
