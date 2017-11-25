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
                var yearInput = int.Parse(Console.ReadLine());
                var result = GetBooksNotRealeasedIn(db, yearInput);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
           
                string[] titles = context.Books
                .Where(r => r.ReleaseDate.Value.Year!=year) 
                .OrderBy(b=>b.BookId)
                .Select(e => e.Title).ToArray();
            

            return $"{string.Join(Environment.NewLine, titles)}";
        }
    }
}
