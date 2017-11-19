namespace P03_SalesDatabase
{ 
    using System;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;

class StartUp
{
    static void Main(string[] args)
    {
            using (var db = new SalesContext())
            {
                db.Database.EnsureDeleted();
              
            }
        }
}
}
