namespace Employees.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Employees.App.Commands.Contracts;
    using Employees.DtoModels;
    using Employees.Services;
    using System.Linq;

    class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var address = string.Join(" ", args.Skip(1));

            employeeService.SetAddress(employeeId, address);

            return $"Address {address} added to employee with id {employeeId}";
        }
    }
}
