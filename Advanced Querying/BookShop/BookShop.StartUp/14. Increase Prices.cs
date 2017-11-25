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
             
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksReleasedAfter2010 = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var price in booksReleasedAfter2010)
            {
                price.Price += 5;
            }

            context.SaveChanges();

            
        }
    }
}
