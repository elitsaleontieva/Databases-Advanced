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
                    .Where(e=>e.Salary > 50000)
                    .OrderBy(e=>e.FirstName)
                    .Select(e=> new
                    {
                        Name=$"{e.FirstName}",
                        
                    });

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.Name}");
                }
                   
            } 
        }
    }
}
