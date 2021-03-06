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
                var result = GetBookTitlesContaining(db, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var resultLast = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
		.OrderBy(n => n.Title)
                .Select(s => s.Title)
                .ToList();




            return $"{string.Join(Environment.NewLine,resultLast)}";
        }
    }
}
