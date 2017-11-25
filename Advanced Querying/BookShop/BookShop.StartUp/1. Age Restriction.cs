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
                var input = Console.ReadLine();
                var result=GetBooksByAgeRestriction(db, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int valueOfEnum = -1;

            switch (command.ToLower())
            {
                case "minor":
                    valueOfEnum = 0;
                break;

                case "teen":
                    valueOfEnum = 1;
                    break;

                case "adult":
                    valueOfEnum = 2;
                    break;

                default:
                    break;
            }

            string[] titles = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)valueOfEnum)
                .Select(t => t.Title).OrderBy(t=>t).ToArray();

            var result = string.Empty;
            foreach (var title in titles)
            {
                result += title;
                result += Environment.NewLine;
            }
          
            
            return result;
        }
    }
}
