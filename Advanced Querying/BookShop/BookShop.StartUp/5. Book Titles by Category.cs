amespace BookShop
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
                var inputCategories = Console.ReadLine().ToLower();
                var result = GetBooksByCategory(db, inputCategories);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var listOfCategories = input.ToLower()
                .Split(new[] {"\t",Environment.NewLine," " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var titles = new List<string>();


            titles = context.Books.Where(b => b.BookCategories.Any(c => listOfCategories.Contains(c.Category.Name.ToLower())))
            .OrderBy(v => v.Title)
            .Select(t => t.Title)
            .ToList();


            return $"{string.Join(Environment.NewLine, titles)}";
        }
    }
}
