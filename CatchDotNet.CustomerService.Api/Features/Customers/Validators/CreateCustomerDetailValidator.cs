﻿using CatchDotNet.CustomerService.Api.Features.Customers.Commands;
using FluentValidation;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Validators
{
    public class CreateCustomerDetailValidator : AbstractValidator<CreateCustomerDetailCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerDetailValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.CustomerDetail.CustomerId).NotEmpty();
            RuleFor(c => c.CustomerDetail.DetailKey).NotEmpty();
            RuleFor(c => c.CustomerDetail.DetailValue).NotEmpty();
           
        }
    }
}
