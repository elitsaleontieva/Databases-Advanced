using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication87
{
    class Person
    {

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName ,string lastName ,int age)
        {
        this.firstName=firstName;
        this.lastName=lastName;
        this.age=age;
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} is a {this.age} years old";
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
}
