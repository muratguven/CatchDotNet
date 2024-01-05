using CatchDotNet.API.ApplicationService.Customers.Dtos;
using CatchDotNet.API.Domains;
using CatchDotNet.API.EntityFrameworkCore;
using CatchDotNet.API.Infrastructure.ApplicationService;
using CatchDotNet.API.Infrastructure.Data;

namespace CatchDotNet.API.ApplicationService.Customers
{
    public class CustomerAppService : AppService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        public CustomerAppService(ICustomerRepository customerRepository, IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCustomerDto> CreateCustomer(CreateCustomerDto input)
        {

            var customer = new Customer(Guid.NewGuid(),input.Name, input.SurName,input.PhoneNumber);
            using(var uow = _unitOfWork) {
                await _customerRepository.InsertAsync(customer);
                _unitOfWork.Commit();

            }
           
            
            return input;
        }
    }
}
