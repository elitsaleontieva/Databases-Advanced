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
                var result = RemoveBooks(db);
                Console.WriteLine($"{result} books were deleted");


            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksWithLessThan4200Copies = context.Books
                .Where(x => x.Copies < 4200).ToList();

            var countOfDeletedBooks = booksWithLessThan4200Copies.Count();

            foreach (var bookToRemove in booksWithLessThan4200Copies)
            {
                context.Books.Remove(bookToRemove);
            }
             context.SaveChanges();

            return countOfDeletedBooks ;
           
           

            
        }
    }
}
