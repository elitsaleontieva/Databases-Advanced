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
                    .Where(e=>e.Department.Name=="Research and Development")
                    .OrderBy(e=>e.Salary).ThenByDescending(e=>e.FirstName)
                    .Select(e=> new
                    {

                        Name=$"{e.FirstName} {e.LastName}",
                        e.Salary,
                        DepartmentName=e.Department.Name
                    });

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Name} from {e.DepartmentName} - ${e.Salary:f2}");
                }
                   
            } 
        }
    }
}
