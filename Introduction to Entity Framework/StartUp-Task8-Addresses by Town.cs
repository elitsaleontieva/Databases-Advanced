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

                var  addresses = db.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        a.AddressText,
                        a.Town.Name,
                        a.Employees.Count
                    })
                    ;

                foreach (var a in addresses)
                {
                    Console.WriteLine($"{a.AddressText}, {a.Name} - {a.Count} employees");
                }
            }
        }
    }
}
