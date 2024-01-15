namespace CatchDotNet.API.ApplicationServices.Customers.Dtos
{
    public record class CustomerDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string SurName { get; init; }

        public string PhoneNumber { get; init; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LasModifiedDate { get; set; }

        
    }
}
