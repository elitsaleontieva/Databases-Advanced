using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Reflection.MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }


            var n = int.Parse(Console.ReadLine());
            Family family = new Family();

            family.People = new List<Person>();

            for (int i = 0; i <n; i++)
            {
                var input = Console.ReadLine();
                var parts = input.Split(' ');
                var name = parts[0];
                var age = int.Parse(parts[1]);
                Person person = new Person();
                person.Age = age;
                person.Name = name;
                family.AddMember(person);
            }
       
            Console.WriteLine("{0} {1}", family.GetOldestMember().Name, family.GetOldestMember().Age);


        }
    }
}


