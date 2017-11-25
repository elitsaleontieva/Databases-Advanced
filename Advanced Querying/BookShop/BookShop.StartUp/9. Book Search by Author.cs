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
                var input = Console.ReadLine().ToLower();
                var result = GetBooksByAuthor(db, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var resultLast = context.Books.Where(r => r.Author.LastName.ToLower().StartsWith(input.ToLower()))
                                      .OrderBy(n => n.BookId)
                                      .Select(a => $"{a.Title} ({a.Author.FirstName} {a.Author.LastName})")
                                      .ToList();




            return $"{string.Join(Environment.NewLine,resultLast)}";
        }
    }
}
