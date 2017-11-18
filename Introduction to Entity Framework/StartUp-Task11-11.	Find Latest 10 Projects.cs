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
                var projects = db.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                });

                foreach (var p in projects)
                {
                    Console.WriteLine(p.Name);
                    Console.WriteLine(p.Description);
                    Console.WriteLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
