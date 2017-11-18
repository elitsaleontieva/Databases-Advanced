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
                var departments = db.Departments
                  .Where(d => d.Employees.Count > 5)
                  .OrderBy(d => d.Employees.Count)
                  .ThenBy(d => d.Name)
                  .Select(d => new
                  {
                      d.Name,
                      d.Manager,
                      d.Employees
                  });

                foreach (var d in departments)
                {
                    Console.WriteLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                    foreach (Employee e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    }

                    Console.WriteLine("----------");
                }
            }
        
            }
    }
}
