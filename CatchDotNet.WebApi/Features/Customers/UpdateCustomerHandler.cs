using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using FluentValidation;
using MediatR;

namespace CatchDotNet.WebApi
{
    public class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand, Guid>
    {
        private readonly ISender _sender;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork<CatchDbContext> _unitOfWork;
        private readonly IValidator<UpdateCustomerCommand> _validator;
        private readonly ILogger<UpdateCustomerHandler> _logger;

        public UpdateCustomerHandler(ISender sender,
            ICustomerRepository customerRepository,
            IUnitOfWork<CatchDbContext> unitOfWork,
            IValidator<UpdateCustomerCommand> validator,
            ILogger<UpdateCustomerHandler> logger)
        {
            _sender = sender;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            using (var uow = _unitOfWork)
            {
                var validation = await  _validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    _logger.LogError("Customer request is not valid!");

                    return Result.Failure<Guid>(new Error("CustomerService.UpdateCustomer", validation.ToString()));

                }

                var customer = await _customerRepository.GetAsync(request.id);
                if(customer is null)
                {
                    _logger.LogError($"Customer not found! Customer Id: {request.id}");
                    return Result.Failure<Guid>(CustomerExceptions.InvalidCustomer);
                }
                customer.SetEmail(request.email);
                customer.SetNameSurname(request.nameSurname);
                customer.SetPhoneNumber(request.phoneNumber);
                customer.SetActive(request.isActive);
                customer.LastModified = DateTime.UtcNow;

                _customerRepository.Update(customer);

                await uow.CommitAsync();

                _logger.LogInformation($"Customer updated id: {request.id} , Date: {customer.LastModified }");
                return Result.Success(customer.Id);
            }

           
        }
    }
}
