﻿

using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi;


public sealed  record CreateCustomerCommand: ICommand
{
        public string NameSurname { get; init; }
        public string Email { get; init; }

        public string PhoneNumber { get; init; }
        public bool IsActive { get; init; }
}
