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
        private double salary;
       

        public Person(string firstName ,string lastName ,int age, double salary)
        {
        this.firstName=firstName;
        this.lastName=lastName;
        this.age=age;
            this.salary = salary;
        }





        public string FirstName { get { return this.firstName; } }

        public int Age { get { return this.age; } }

        public void IncreaseSalary(double bonus)
        {
            if (this.age > 30)
                this.salary += this.salary * bonus / 100;
            else
                this.salary += this.salary * bonus / 200;
        }


        public override string ToString()
        {
            return $"{this.firstName} get {this.salary:f2} leva";
        }

    }
}
