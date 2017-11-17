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



                var employees = db.Employees
                    .Where(
                        e => e.EmployeeProjects.Any(ep =>
                        ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                        .Take(30)
                    .Select(e => new
                        {
                        Name = $"{e.FirstName} {e.LastName}",
                        ManagerName=$"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects=e.EmployeeProjects
                            .Select(ep=> new { ep.Project.Name, ep.Project.StartDate, ep.Project.EndDate})
                        })
                     ;
                  

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Name} - Manager: {e.ManagerName}");

                    foreach (var ep in e.Projects)
                    {
                        Console.Write($"--{ep.Name} - {ep.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - ");
                        if (ep.EndDate!=null)
                        {
                            Console.WriteLine($"{ep.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                        }
                        else
                        {
                            Console.WriteLine("not finished");
                        }
                    }
                }
                   
            } 
        }
    }
}
