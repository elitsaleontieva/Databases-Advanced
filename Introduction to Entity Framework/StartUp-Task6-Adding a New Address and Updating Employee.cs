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


                var adress = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };
                db.Addresses.Add(adress); // add the new adress to the database

                var updatedEmployee = db.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
                updatedEmployee.Address = adress;

                db.SaveChanges();

                var addressText=db.Employees
                    .OrderByDescending(e=>e.AddressId)
                    .Select(e => new
                {

                   e.Address.AddressText
                    
                });






                foreach (var a in addressText.Take(10))
                {
                    Console.WriteLine($"{a.AddressText}");
                }
                   
            } 
        }
    }
}
