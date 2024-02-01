using CatchDotNet.Core.Exceptions;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
using MediatR;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, List<CustomerResponse>>
    {

        public readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<List<CustomerResponse>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetListAsync();

            var result = customers.SelectMany(s =>
            {
                return new List<CustomerResponse>
                {
                   new CustomerResponse
                   {
                       Id = s.Id,
                       NameSurname=s.NameSurname,
                       Email = s.Email,
                       PhoneNumber = s.PhoneNumber,
                       IsActive = s.IsActive

                   }
                };
            });

            return Result.Success(result.ToList());
        }
    }
}
