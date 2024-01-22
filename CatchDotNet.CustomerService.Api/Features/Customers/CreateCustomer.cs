using Carter;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Exceptions;
using FluentValidation;
using MediatR;
using static CatchDotNet.CustomerService.Api.Features.Customers.CreateCustomer;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public static class CreateCustomer
    {
        public class Command: IRequest<Result>
        {
            public string NameSurname { get; init; }
            public string Email { get; init; }

            public string PhoneNumber { get; init; }
            public bool IsActive { get; init; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c=>c.NameSurname).NotEmpty();
                RuleFor(c=>c.Email).NotEmpty();
                RuleFor(c=>c.PhoneNumber).NotEmpty();
            }
        }

        internal sealed class Handler : IRequestHandler<Command,Result>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IUnitOfWork<CustomerDbContext> _unitOfWork;
            private readonly IValidator<Command> _validator;
            private readonly ILogger<Handler> _logger;

            public Handler(ICustomerRepository customerRepository,
                IUnitOfWork<CustomerDbContext> unitOfWork,
                IValidator<Command> validator,
                ILogger<Handler> logger)
            {
                _customerRepository = customerRepository;
                _unitOfWork = unitOfWork;
                _validator = validator;
                _logger = logger;
            }



            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {

                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _logger.LogError(validationResult.ToString());
                    return Result.Failure(new Error("CustomerService.CreateCustomer", validationResult.ToString()));
                }

                var customer = new Customer(Guid.NewGuid(),request.NameSurname,request.Email,request.PhoneNumber,request.IsActive);

                using(var uow = _unitOfWork)
                {
                    await _customerRepository.InsertAsync(customer);
                    await _unitOfWork.CommitAsync();
                }

                _logger.LogInformation($"New customer was added Id : {customer.Id}, NameSurname:{customer.NameSurname}");

                return Result.Success();
            }

         


        }

   
    }

    public class CreateCustomerEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/customers", async (Command command, ISender sender) => {

                var result = await sender.Send(command);
                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }
                return Results.Ok();
            });
        }
    }
}
