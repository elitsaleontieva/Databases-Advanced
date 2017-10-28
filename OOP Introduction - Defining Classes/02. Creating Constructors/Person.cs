using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Person
    {
    public Person() // This is the private constructor.
    {
        this.Age = 1;
        this.Name = "No name";

       

    }

    public Person(int age) // This is the private constructor.
    {
        this.Age = age;
        this.Name = "No name";
  
    }
    public Person(string name, int age) // This is the private constructor.
    {
        this.Age = age;
        this.Name = name;

    }


    public String Name { get; set; }
    public int Age { get; set; }

}

