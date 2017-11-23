namespace P01_BillsPaymentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using P01_BillsPaymentSystem.Data.EntityConfig;

    public class BillsPaymentSystemContext : DbContext
    {

        public BillsPaymentSystemContext()
        {

        }

        public BillsPaymentSystemContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());



        }
    }
}
