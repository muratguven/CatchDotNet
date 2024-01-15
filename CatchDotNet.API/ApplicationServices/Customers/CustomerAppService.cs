using AutoMapper;
using CatchDotNet.API.ApplicationServices.Customers.Dtos;
using CatchDotNet.API.Domains;
using CatchDotNet.API.EntityFrameworkCore;
using CatchDotNet.Core.ApplicationService;
using CatchDotNet.Core.Data;

namespace CatchDotNet.API.ApplicationServices.Customers
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        public CustomerAppService(ICustomerRepository customerRepository, IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper):base(mapper)
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

        public async Task<List<CustomerDto>> GetAll()
        {
            var customers = await _customerRepository.GetListAsync();

            var result = Mapper.Map<List<CustomerDto>>(customers);
            return result;
        }
    }
}
