namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using System.Linq;
    using BookShop.Models;
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading;
   


    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new BookShopContext())
            {
               DbInitializer.ResetDatabase(db);
                var input = Console.ReadLine();
                var result = GetAuthorNamesEndingIn(db, input);
                Console.WriteLine(result);
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var lengthOfInput = input.Length;


            var resultLast = context.Authors.Where(r => r.FirstName.EndsWith(input))
                                      .OrderBy(n => $"{n.FirstName} {n.LastName}")
                                      .Select(a => $"{a.FirstName} {a.LastName}")
                                      .ToList();




            return $"{string.Join(Environment.NewLine,resultLast)}";
        }
    }
}
