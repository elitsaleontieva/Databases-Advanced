using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;


namespace P02_DatabaseFirst
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (var db = new SoftUniContext())
            {
                var employees=db.Employees
                    .OrderBy(e=>e.EmployeeId)
                    .Select(e=> new
                    {
                        Name=$"{e.FirstName} {e.LastName} {e.MiddleName}",
                        e.JobTitle,
                        e.Salary
                    });

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Name} {e.JobTitle} {e.Salary:f2}");
                }
                   
            } 
        }
    }
}
