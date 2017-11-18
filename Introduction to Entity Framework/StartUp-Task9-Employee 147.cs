using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;
using System.Globalization;

namespace P02_DatabaseFirst
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (var db = new SoftUniContext())
            {

                var employeesProjects = db.EmployeesProjects
                    .OrderBy(ep=> ep.Project.Name)
                    .Where(ep=> ep.EmployeeId==147)
                    .Select(ep => new
                    {
                        ep.Employee.FirstName,
                        ep.Employee.LastName,
                        ep.Employee.JobTitle,
                    
                    })
                    .FirstOrDefault();


                var projects = db.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .Where(ep => ep.EmployeeId == 147)
                    .Select(ep => new
                    {
                        ep.Employee.FirstName,
                        ep.Employee.LastName,
                        ep.Employee.JobTitle,
                        ep.Project.Name
                    })
                    .Take(10);



                Console.WriteLine($"{employeesProjects.FirstName} {employeesProjects.LastName} - {employeesProjects.JobTitle}");

                foreach (var p in projects)
                {
                    Console.WriteLine($"{p.Name}");
                 
                    
                }
            }
        }
    }
}
