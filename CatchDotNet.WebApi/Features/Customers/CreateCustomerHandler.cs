using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using FluentValidation;

namespace CatchDotNet.WebApi;

internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IUnitOfWork<CatchDbContext> _unitOfWork;
            private readonly IValidator<CreateCustomerCommand> _validator;
            private readonly ILogger<CreateCustomerHandler> _logger;

            public CreateCustomerHandler(ICustomerRepository customerRepository,
                IUnitOfWork<CatchDbContext> unitOfWork,
                IValidator<CreateCustomerCommand> validator,
                ILogger<CreateCustomerHandler> logger)
            {
                _customerRepository = customerRepository;
                _unitOfWork = unitOfWork;
                _validator = validator;
                _logger = logger;
            }



            public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {

                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _logger.LogError(validationResult.ToString());
                    return Result.Failure(new Error("CustomerService.CreateCustomer", validationResult.ToString()));
                }

                var customer = new Customer(Guid.NewGuid(),request.NameSurname,request.Email,request.PhoneNumber,request.IsActive);
                customer.CreatedDate = DateTime.UtcNow;

                using(var uow = _unitOfWork)
                {
                    await _customerRepository.InsertAsync(customer);
                    await _unitOfWork.CommitAsync();
                }

                _logger.LogInformation($"New customer was added Id : {customer.Id}, NameSurname:{customer.NameSurname}");

                return Result.Success();
            }

         


        }

   
    

