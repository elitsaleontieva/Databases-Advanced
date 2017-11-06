using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateOneInput = Console.ReadLine();
            var dateTwoInput = Console.ReadLine();
            DateModifier dm = new DateModifier(dateOneInput,dateTwoInput);
            

            Console.WriteLine(dm.dateDiff(dateOneInput, dateTwoInput));
     
          
        }
    }
}
