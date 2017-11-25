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
                var result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var resultLast = context.Categories
                .OrderByDescending(b=>b.CategoryBooks.Sum(x=>x.Book.Price*x.Book.Copies)).ThenBy(c=>c.Name)
                .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(x=>x.Book.Price * x.Book.Copies):f2}" )
                .ToList();
            
            return $"{string.Join(Environment.NewLine,resultLast)}";
        }
    }
}
