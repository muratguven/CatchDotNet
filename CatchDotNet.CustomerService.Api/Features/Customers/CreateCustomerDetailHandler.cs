using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using CatchDotNet.CustomerService.Api.Exceptions.Customers;
using CatchDotNet.CustomerService.Api.Features.Customers.Commands;
using FluentValidation;
using MediatR;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public class CreateCustomerDetailHandler : ICommandHandler<CreateCustomerDetailCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerDetailHandler> _logger;
        private readonly IUnitOfWork<CustomerDbContext> _unitOfWork;
        private readonly IValidator<CreateCustomerDetailCommand> _validator;

        public CreateCustomerDetailHandler(ICustomerRepository customerRepository,
                                           ILogger<CreateCustomerDetailHandler> logger,
                                           IUnitOfWork<CustomerDbContext> unitOfWork,
                                           IValidator<CreateCustomerDetailCommand> validator)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }


        public async Task<Result> Handle(CreateCustomerDetailCommand request, CancellationToken cancellationToken)
        {

            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                _logger.LogError($"Customer detail request not valid! {validation.Errors.FirstOrDefault().ErrorMessage}");
                return Result.Failure(new Error(validation.Errors.FirstOrDefault().ErrorCode,validation.Errors.FirstOrDefault().ErrorMessage));
            }

            using(var uow = _unitOfWork)
            {

                var customerDetail = new CustomerDetail(request.CustomerId, request.CustomerDetail.DetailKey, request.CustomerDetail.DetailValue);
                await _customerRepository.CreateCustomerDetailAsync(request.CustomerId, customerDetail, cancellationToken);
                _logger
                    .LogInformation($"CustomerService.CustomerDetail: Added new customer detail customer : " +
                    $"{request.CustomerId} , " +
                    $"Key: {request.CustomerDetail.DetailKey} " +
                    $"Value: {request.CustomerDetail.DetailValue} ");


               var result = await uow.CommitAsync();

                return Result.Success();
            }

        }
    }
}
