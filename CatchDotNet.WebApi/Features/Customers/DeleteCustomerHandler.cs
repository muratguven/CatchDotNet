using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using CatchDotNet.WebApi.Commands;

namespace CatchDotNet.WebApi
{
    public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork<CatchDbContext> _unitOfWork;
        private readonly ILogger<DeleteCustomerHandler> _logger;

        public DeleteCustomerHandler(ICustomerRepository customerRepository, 
            IUnitOfWork<CatchDbContext> unitOfWork, 
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
