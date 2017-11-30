namespace Employees.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Employees.App.Commands.Contracts;
    using Employees.DtoModels;
    using Employees.Services;

    class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<firstname> <lastname> <salary>
        public string Execute(params string[] args)
        {
          
            var firstName = args[0];
            var lastName = args[1];
            var salary = decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto(firstName,lastName,salary);

            employeeService.AddEmployee(employeeDto);



            return $"Employee: {firstName} {lastName} was added sucessfully!";
        }
    }
}
