using CatchDotNet.Core.Domain;
using System.Diagnostics.CodeAnalysis;

namespace CatchDotNet.CustomerService.Api;

public class Customer : AuditedAggregateRoot
{
    protected Customer() 
    { 
    
        Details = new List<CustomerDetail>();
    }

    public Customer(Guid id, string nameSurname, string email, string phoneNumber, bool isActive)
    {
        Id = id;
        NameSurname = nameSurname;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
        Details = new List<CustomerDetail>();
    }

    public string NameSurname { get; private set; }
    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }
    public bool IsActive { get; private set; }

    public ICollection<CustomerDetail> Details { get; private set; }

    public void SetNameSurname([NotNull] string nameSurname) => NameSurname = nameSurname;

    public void SetEmail([NotNull] string email) => Email = email;

    public void SetPhoneNumber([NotNull] string phoneNumber) => PhoneNumber = phoneNumber;

    public void SetActive(bool isActive) => IsActive = isActive;

    public void AddDetail(CustomerDetail detail) => Details.Add(detail);

    public void AddDetail(string key, string value) => Details.Add(new CustomerDetail(Guid.NewGuid(), Id, key, value));

    public void RemoveDetail(string key)
    {
        var detail = Details.FirstOrDefault(x=>x.DetailKey==key);
        if( detail is not null)
        {
            Details.Remove(detail);
        }
        
    }
   

}
