using CatchDotNet.Core.Domain;
using System.Diagnostics.CodeAnalysis;

namespace CatchDotNet.CustomerService.Api
{
    public class CustomerDetail : Entity, ISoftDeleteEntity
    {
        protected CustomerDetail() { }

        protected CustomerDetail(Guid id, 
            Guid customerId, 
            [NotNull]string detailKey, 
            [NotNull]string detailValue)
        {
            
        }

        public Guid CustomerId { get; private set; }
        public string DetailKey {  get; private set; }
        public string DetailValue { get; private set;}

        public Customer Customer { get;  set; }
        public bool IsDeleted { get; set; }

        public void SetCustomer(Guid customerId)=>CustomerId = customerId;
     

        public void SetDetailKey([NotNull]string detailKey)=>DetailKey = detailKey;
        

        public void SetDetailValue([NotNull]string detailValue) => DetailValue = detailValue;
      

    }
}
