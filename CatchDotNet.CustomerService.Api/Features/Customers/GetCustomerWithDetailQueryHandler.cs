using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Dtos;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public class GetCustomerWithDetailQueryHandler : IQueryHandler<GetCustomerWithDetailQuery, CustomerWithDetailDto>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomerWithDetailQueryHandler> _logger;

        public GetCustomerWithDetailQueryHandler(ICustomerRepository customerRepository,
                                                 ILogger<GetCustomerWithDetailQueryHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result<CustomerWithDetailDto>> Handle(GetCustomerWithDetailQuery request, CancellationToken cancellationToken)
        {

            var query =  _customerRepository.GetAll();

            var customer = await query.Where(x => x.Id == request.Id).Include(x => x.Details).FirstOrDefaultAsync();

            if(customer is null)
            {
                _logger.LogError($"{request.Id} Id's customer is not found!");
                return (Result<CustomerWithDetailDto>)Result.Failure(new Error($"{request.Id} Id's customer is not found!"));
            }
                       
            var result = customer.Adapt<CustomerWithDetailDto>();
   
            return Result.Success(result);
         
        }
    }
}
