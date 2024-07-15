using CatchDotNet.Core;

namespace CatchDotNet.WebApi
{
    public static class CustomerExceptions
    {
        public static readonly Error SameCustomer =  new ("CustomerService.SameCustomer", "Customer is already registered!");

        public static readonly Error InvalidCustomer = new("CustomerService.InvalidCustomer", "Customer not found!");

        public static readonly Error InvalidCustomerDetail = new("CustomerService.CustomerDetail", "Customer Detail Request not valid!");
    }
}
