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
                var result = GetMostRecentBooks(db);
                Console.WriteLine(result);
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var resultLast = context.Categories
                .OrderBy(m=>m.Name)
                .Select(c => $"--{c.Name}{Environment.NewLine}{string.Join(Environment.NewLine, c.CategoryBooks.OrderByDescending(j => j.Book.ReleaseDate).Take(3).Select(z => $"{z.Book.Title} ({z.Book.ReleaseDate.Value.Year})"))}")
                .ToList();


            return $"{string.Join(Environment.NewLine,resultLast)}";
        }
    }
}
