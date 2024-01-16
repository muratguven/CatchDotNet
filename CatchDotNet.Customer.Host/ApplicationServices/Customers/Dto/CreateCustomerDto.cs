namespace CatchDotNet.Customer.Host.ApplicationServices.Customers.Dto
{
    public record class CreateCustomerDto
    {
        public required string NameSurname { get; init; }
        public required string Email { get;  init; }

        public required string PhoneNumber { get;  init; }
        public required bool IsActive { get;  init; }


    }
}
