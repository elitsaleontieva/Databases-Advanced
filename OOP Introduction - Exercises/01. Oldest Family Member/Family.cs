using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Oldest_Family_Member
{
    class Family : Person
    {
        public List<Person> People= new List<Person>();

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(x=>x.Age).First();
        }
    }
}
