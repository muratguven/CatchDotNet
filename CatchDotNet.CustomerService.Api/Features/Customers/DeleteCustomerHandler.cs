using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using CatchDotNet.CustomerService.Api.Features.Customers.Commands;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork<CustomerDbContext> _unitOfWork;
        private readonly ILogger<DeleteCustomerHandler> _logger;

        public DeleteCustomerHandler(ICustomerRepository customerRepository, 
            IUnitOfWork<CustomerDbContext> unitOfWork, 
            ILogger<DeleteCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            using(var uow = _unitOfWork)
            {
                _customerRepository.Delete(request.Id);
                await uow.CommitAsync();
                _logger.LogInformation($"Customer Deleted! Customer Id: {request.Id} - {DateTime.Now.ToString()}");

            }

            return Result.Success();

        }
    }
}
