using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.Core.Pagination;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;

namespace CatchDotNet.WebApi
{
    public class GetPagedListCustomerQueryHandler : IQueryHandler<GetPagedCustomerListQuery, PagedResults<CustomerDto>>
    {

        private readonly ICustomerRepository _customerRepository;

        public GetPagedListCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<PagedResults<CustomerDto>>> Handle(GetPagedCustomerListQuery request, CancellationToken cancellationToken)
        {


            var results = await _customerRepository.GetPagedListAsync(request.Skip, request.PageSize,cancellationToken);

            var totalCount = await _customerRepository.GetTotalCountAsync(cancellationToken);

            var responseList = results.SelectMany(s =>{

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

            }).ToList();

            var response = new PagedResults<CustomerDto>(responseList, totalCount, request.CurrentPage, request.PageSize);
            return Result.Success(response);

        }
    }
}
