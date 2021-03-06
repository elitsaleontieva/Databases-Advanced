using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    class Program
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length,width,height);

            Console.WriteLine("Surface Area - {0:F2}", box.SurfaceArea());
            Console.WriteLine("Lateral Surface Area - {0:F2}", box.LateralSurfaceArea());
            Console.WriteLine("Volume - {0:F2}", box.Volume());



        }
    }
}
