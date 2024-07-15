using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.WebApi
{
    public class DeleteCustomerDetailHandler : ICommandHandler<DeleteCustomerDetailCommand>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork<CatchDbContext> _unitOfWork;
        private readonly ILogger<DeleteCustomerDetailHandler> _logger;

        public DeleteCustomerDetailHandler(ICustomerRepository customerRepository,
                                           IUnitOfWork<CatchDbContext> unitOfWork,
                                           ILogger<DeleteCustomerDetailHandler> logger)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteCustomerDetailCommand request, CancellationToken cancellationToken)
        {

            var detail = await _customerRepository.GetAll()
                .Include(i => i.Details)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();
            if(detail is null)
            {
                _logger.LogError($"{request.Id} customer Id's and {request.Key} detail's key record not found ");
                return Result.Failure(new Error($"{request.Id} customer Id's and {request.Key} detail's key record not found "));
            }

            detail.RemoveDetail(request.Key);

            using(var uow = _unitOfWork)
            {

                _customerRepository.Update(detail);
                await uow.CommitAsync();

                return Result.Success();
            }

        }
    }
}
