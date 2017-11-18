

namespace P01_HospitalDatabase //CHANGE THE NAMESPACE FROM HospitalStartUp
{
    using System;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db=new HospitalContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
