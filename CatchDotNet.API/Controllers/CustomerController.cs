﻿using CatchDotNet.API.ApplicationService.Customers;
using CatchDotNet.API.ApplicationService.Customers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatchDotNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase, ICustomerAppService
    {

        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost]
        public Task<CreateCustomerDto> CreateCustomer(CreateCustomerDto customer)
        {
            return _customerAppService.CreateCustomer(customer);
        }

        

    }
}