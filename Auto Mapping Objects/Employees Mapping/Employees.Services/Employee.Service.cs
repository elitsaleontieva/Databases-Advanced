namespace Employees.Services
{
    using System;
    using Employees.Data;
    using Employees.DtoModels;
    using AutoMapper;
    using Employees.Models;

    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date) 
        {
            var employee = context.Employees.Find(employeeId);
            employee.Birthday = date;
           

            context.SaveChanges();
        }

        public void SetAddress(int employeeId,string address)
        {
            var employee = context.Employees.Find(employeeId);
            employee.Address = address; 


            context.SaveChanges();
        }

        public string EmployeeInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            return $"ID: {employee.ID} {employee.FirstName} {employee.LastName} {employee.Salary:f2}";
        }

        public string EmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var address = string.Empty;
            if (employee.Address == null)
            {
                address = "No address specified!";
            }
            else
            {
                address = $"{employee.Address}";
            }


            var birthday =  string.Empty;
            if (employee.Birthday.ToString() == string.Empty)
            {
                birthday = "No birthday specified!";
            }
            else
            {
                birthday = $"{employee.Birthday.Value.Day}-{employee.Birthday.Value.Month}-{employee.Birthday.Value.Year}";
            }
            return $"ID: {employee.ID} - {employee.FirstName} {employee.LastName} - {employee.Salary:F2}" +
                Environment.NewLine +
                $"Birthday: {birthday}" +
                Environment.NewLine +
                $"Address: {address}";
        }
    }


}
