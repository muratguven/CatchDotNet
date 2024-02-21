using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Dtos;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, List<CustomerDto>>
    {

        public readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<List<CustomerDto>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
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
