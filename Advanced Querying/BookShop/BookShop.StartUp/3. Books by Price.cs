namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using System.Linq;
    using BookShop.Models;
    using System;
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new BookShopContext())
            {
               DbInitializer.ResetDatabase(db);
                var result= GetBooksByPrice(db);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            string[] titlesAndPrices = context.Books
                .Where(p=>p.Price>40)
                .OrderByDescending(pr=>pr.Price)
                .Select(t=> $"{t.Title} - ${t.Price:f2}")
                .ToArray();


            return $"{string.Join(Environment.NewLine, titlesAndPrices)}";
        }
    }
}
