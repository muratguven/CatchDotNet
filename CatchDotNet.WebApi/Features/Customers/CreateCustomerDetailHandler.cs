using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using FluentValidation;

namespace CatchDotNet.WebApi
{
    public class CreateCustomerDetailHandler : ICommandHandler<CreateCustomerDetailCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerDetailHandler> _logger;
        private readonly IUnitOfWork<CatchDbContext> _unitOfWork;
        private readonly IValidator<CreateCustomerDetailCommand> _validator;
        private readonly ICustomerDetailKeyRepository _customerDetailKeyRepository;

        public CreateCustomerDetailHandler(ICustomerRepository customerRepository,
                                           ILogger<CreateCustomerDetailHandler> logger,
                                           IUnitOfWork<CatchDbContext> unitOfWork,
                                           IValidator<CreateCustomerDetailCommand> validator,
                                           ICustomerDetailKeyRepository customerDetailKeyRepository)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _customerDetailKeyRepository = customerDetailKeyRepository;
        }


        public async Task<Result> Handle(CreateCustomerDetailCommand request, CancellationToken cancellationToken)
        {

            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                _logger.LogError($"Customer detail request not valid! {validation.Errors?.FirstOrDefault()?.ErrorMessage}");
                return Result.Failure(new Error(validation.Errors?.FirstOrDefault()?.ErrorCode,validation.Errors?.FirstOrDefault()?.ErrorMessage));
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


                await _customerDetailKeyRepository.CreateIndex("customer-keys");
                var document = new CustomerDetailKey
                {                    
                    Key = request.CustomerDetail.DetailKey,
                };
                await _customerDetailKeyRepository.InsertDocumentAsync(document,"customer-keys",cancellationToken);

                return Result.Success();
            }

        }
    }
}
