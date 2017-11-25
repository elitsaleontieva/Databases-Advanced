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
                var input = int.Parse(Console.ReadLine());
                var result = CountBooks(db, input);
                Console.WriteLine(result);
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var resultLast = context.Books
                                      .Where(x=>x.Title.Length>lengthCheck)
                                      .ToList();

            return resultLast.Count();
        }
    }
}
