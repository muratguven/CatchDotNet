using FluentValidation;

namespace CatchDotNet.WebApi;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
            RuleFor(x=>x.nameSurname).NotEmpty();
            RuleFor(x=>x.email).NotEmpty();
            RuleFor(x=>x.phoneNumber).NotEmpty();
            
    }
}
