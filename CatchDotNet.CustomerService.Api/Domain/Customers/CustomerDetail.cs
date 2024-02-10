using CatchDotNet.Core.Domain;
using System.Diagnostics.CodeAnalysis;

namespace CatchDotNet.CustomerService.Api
{
    public class CustomerDetail : Entity, ISoftDeleteEntity
    {
        public CustomerDetail() { }

        internal CustomerDetail(Guid id, 
            Guid customerId, 
            [NotNull]string detailKey, 
            [NotNull]string detailValue)
        {
         Id = id;
        CustomerId = customerId;
         DetailKey = detailKey;
         DetailValue = detailValue;
        }


        internal CustomerDetail(
           Guid customerId,
           [NotNull] string detailKey,
           [NotNull] string detailValue)
        {
            CustomerId = customerId;
            DetailKey = detailKey;
            DetailValue = detailValue;
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
