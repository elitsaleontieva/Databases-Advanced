using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankind
{
    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
        }

 

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
           if (value.Length < 5 || value.Length > 10 || !ValidFN(value))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                    }

                    this.facultyNumber = value;
                }
            }

        private bool ValidFN(string value)
        {
            bool validFN = true;
            foreach (char ch in value)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    validFN = false;
                }
            }

            return validFN;
        }


   
    }
}