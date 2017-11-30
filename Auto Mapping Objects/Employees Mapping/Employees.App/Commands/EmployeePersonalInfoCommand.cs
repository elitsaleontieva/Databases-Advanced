

namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Employees.DtoModels;
    using Employees.Services;


    class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {

            int employeeId = int.Parse(args[0]);
            
            return employeeService.EmployeePersonalInfo(employeeId);
        }
    }
}
