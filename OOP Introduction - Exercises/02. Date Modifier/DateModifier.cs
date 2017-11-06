using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Date_Modifier
{
    class DateModifier
    {
        public String DateOne { get; set; }
        public String DateTwo { get; set; }

        public DateModifier(string dateone,string datetwo)
        {
            this.DateOne = dateone;
            this.DateTwo = datetwo;
        }
        public string dateDiff(string dateOneStr,string dateTwoStr)
        {
           
            var firstDateInput = dateOneStr.Split(' ');
            var secondDateInput = dateTwoStr.Split(' ');

            DateTime dt = Convert.ToDateTime(string.Join(" ", firstDateInput));
            DateTime dtTwo = Convert.ToDateTime(string.Join(" ", secondDateInput));

            DateTime dateOne = new DateTime(dt.Year, dt.Month, dt.Day);
            DateTime dateTwo = new DateTime(dtTwo.Year, dtTwo.Month, dtTwo.Day);
           
            TimeSpan difference = dateOne.Subtract(dateTwo);
            var differenceBetweenDays = difference.TotalDays.ToString().Replace("-","");
            return differenceBetweenDays;
            
        }
        
       

        
        //Console.WriteLine("Year: {0}, Month: {1}, Day: {2}",  
          //                    dt.Year, dt.Month, dt.Day);  

       // TimeSpan difference = dateOne.Subtract(dateTwo);

        
        //Console.WriteLine(Math.Abs(difference.TotalDays));
    }
}
