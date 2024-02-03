using FluentValidation;

namespace CatchDotNet.CustomerService.Api.Features.Customers;


    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c=>c.NameSurname).NotEmpty();
            RuleFor(c=>c.Email).NotEmpty();
            RuleFor(c=>c.PhoneNumber).NotEmpty();
        }
    }
