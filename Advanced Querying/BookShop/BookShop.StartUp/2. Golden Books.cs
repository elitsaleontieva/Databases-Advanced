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
                var result= GetGoldenBooks(db);
                Console.WriteLine(result);
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] titles = context.Books
                .Where(c => c.Copies < 5000 && c.EditionType==EditionType.Gold)
                .OrderBy(i=>i.BookId)
                .Select(t => t.Title).ToArray();


            return $"{string.Join(Environment.NewLine, titles)}";
        }
    }
}
