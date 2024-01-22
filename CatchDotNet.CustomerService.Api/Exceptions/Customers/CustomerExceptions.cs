using CatchDotNet.Core.Exceptions;

namespace CatchDotNet.CustomerService.Api.Exceptions.Customers
{
    public static class CustomerExceptions
    {
        public static readonly Error SameCustomer =  new ("CustomerService.SameCustomer", "Customer is already registered!");

        public static readonly Error InvalidCustomer = new("CustomerService.InvalidCustomer", "Cus");
    }
}
