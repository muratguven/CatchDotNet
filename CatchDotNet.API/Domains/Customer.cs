using CatchDotNet.API.Infrastructure.Domain;

namespace CatchDotNet.API.Domains
{
    public class Customer : AuditedEntity<Guid>
    {
        protected Customer() { }
        public Customer(Guid id, string name, string surname, string phoneNumber)
        {
            Id = id;
            Name = name;
            SurName = surname;
            PhoneNumber = phoneNumber;
        }
        public string Name { get; private set; }
        public string SurName { get; private set; }

        public string PhoneNumber { get; private set; }

        
    }
}
