using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class Program
    {
       
        static void Main(string[] args)
      {

        int n = int.Parse(Console.ReadLine());
        Person[] persons = new Person[n];
      //  Person[] persons = new Person[n];

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            var parts = input.Split(' ').ToArray();
            var name = parts[0];
            var age = int.Parse(parts[1]);
            persons[i] = new Person(name, age);
        }
        List<Person> result = persons.ToList();
        foreach (var item in result.OrderBy(x=>x.Name))
        {
           
            if (item.Age>30)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
       


 

    }

}


