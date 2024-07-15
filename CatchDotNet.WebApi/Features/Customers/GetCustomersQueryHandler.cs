using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers;

namespace CatchDotNet.WebApi
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, List<CustomerDto>>
    {

        public readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<List<CustomerDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetListAsync();

            var result = customers.SelectMany(s =>
            {
                return new List<CustomerDto>
                {
                   new CustomerDto
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
