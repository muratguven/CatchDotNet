using CatchDotNet.Core.Domain;

namespace CatchDotNet.API.Domains
{
    public class Customer : AuditedEntity<Guid>
    {
        public Customer() { }
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

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetSurName(string surName)
        {
            SurName = surName;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        
    }
}
