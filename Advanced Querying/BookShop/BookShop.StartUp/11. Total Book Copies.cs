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
                var result = CountCopiesByAuthor(db);
                Console.WriteLine(result);
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var resultLast = context.Authors
                                      .OrderByDescending(c=>c.Books.Sum(a=>a.Copies))
                                      .Select(a =>  $"{a.FirstName} {a.LastName} - {a.Books.Sum(c=>c.Copies)}" )
                                      .ToList();
            
            return $"{string.Join(Environment.NewLine,resultLast)}";
        }
    }
}
