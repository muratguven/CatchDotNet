using CatchDotNet.CustomerService.Api.Features.Customers.Commands;
using FluentValidation;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
                RuleFor(x=>x.nameSurname).NotEmpty();
                RuleFor(x=>x.email).NotEmpty();
                RuleFor(x=>x.phoneNumber).NotEmpty();
                
        }
    }
}
