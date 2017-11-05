using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string firstName = tokens[0];
            string lastName = tokens[1];
            string facultyNumber = tokens[2];
            Student student;
            try
            {
                student = new Student(firstName, lastName, facultyNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            input = Console.ReadLine();
            tokens = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            firstName = tokens[0];
            lastName = tokens[1];
            double weekSalary = double.Parse(tokens[2]);
            double hoursPerDay = double.Parse(tokens[3]);

            Worker worker;
            try
            {
                worker = new Worker(firstName, lastName, weekSalary, hoursPerDay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine($"First Name: {student.FirstName}{Environment.NewLine}Last Name: {student.LastName}{Environment.NewLine}Faculty number: {student.FacultyNumber}");

            Console.WriteLine();
            Console.WriteLine($"First Name: {worker.FirstName}{Environment.NewLine}Last Name: {worker.LastName}{Environment.NewLine}Week Salary: {worker.WeekSalary:f2}{Environment.NewLine}Hours per day: {worker.WorkHoursPerDay:f2}{Environment.NewLine}Salary per hour: {(worker.WeekSalary / (worker.WorkHoursPerDay * 5)):f2}");
                  



        }
                    }
}