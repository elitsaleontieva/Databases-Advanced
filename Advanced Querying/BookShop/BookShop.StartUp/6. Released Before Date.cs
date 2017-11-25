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
                var result = GetBooksReleasedBefore(db, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var inputToDate = DateTime.ParseExact($"{date}", "dd-MM-yyyy", null);
            Console.WriteLine(inputToDate);

            var result = context.Books.Where(r => inputToDate>r.ReleaseDate.Value)
                                      .OrderByDescending(rd => rd.ReleaseDate.Value)
                                      .Select(c => $"{c.Title} - {c.EditionType} - ${c.Price:f2}")
                                      .ToList();


            return $"{string.Join(Environment.NewLine,result)}";
        }
    }
}
