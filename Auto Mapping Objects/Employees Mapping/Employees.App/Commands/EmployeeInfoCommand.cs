using Employees.App.Commands.Contracts;
using Employees.DtoModels;
using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    class EmployeeInfoCommand : ICommand
    {
            private readonly EmployeeService employeeService;

            public EmployeeInfoCommand(EmployeeService employeeService)
            {
                this.employeeService = employeeService;
            }

            //<firstname> <lastname> <salary>
            public string Execute(params string[] args)
            {

                int employeeId = int.Parse(args[0]);

                employeeService.EmployeeInfo(employeeId);



                return employeeService.EmployeeInfo(employeeId);
            }
        }
    }
