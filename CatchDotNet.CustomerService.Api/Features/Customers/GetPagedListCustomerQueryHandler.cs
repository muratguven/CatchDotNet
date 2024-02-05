using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.Core.Pagination;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
using MediatR;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public class GetPagedListCustomerQueryHandler : IQueryHandler<GetPagedCustomerListQuery, PagedResults<CustomerResponse>>
    {

        private readonly ICustomerRepository _customerRepository;

        public GetPagedListCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<PagedResults<CustomerResponse>>> Handle(GetPagedCustomerListQuery request, CancellationToken cancellationToken)
        {


            var results = await _customerRepository.GetPagedListAsync(request.CurrentPage, request.PageSize);

            var totalCount = await _customerRepository.GetTotalCountAsync();

            var responseList = results.SelectMany(s =>{

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

            }).ToList();

            return Result.Success(new PagedResults<CustomerResponse>(responseList, totalCount,request.CurrentPage,request.PageSize));

        }
    }
}
