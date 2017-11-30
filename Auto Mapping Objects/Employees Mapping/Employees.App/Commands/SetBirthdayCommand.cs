namespace Employees.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Employees.App.Commands.Contracts;
    using Employees.DtoModels;
    using Employees.Services;
    using System.Globalization;
    

    class SetBirthdayCommand : ICommand
    {
        //<employeeId> <date: "dd-MM-yyyy"> 

        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null );

            employeeService.SetBirthday(employeeId,date);

            return $"Birthday {args[1]} added to employee with id {employeeId}";
        }
        
    }
}
