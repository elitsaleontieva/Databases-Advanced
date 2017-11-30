namespace Employees.Data 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Employees.Data;
    using Employees.Models;
    using Employees.Data.Configurations;

   public class EmployeesContext : DbContext
    {
        public EmployeesContext()
        {

        }

        public EmployeesContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        //public DbSet<CreditCard> CreditCards { get; set; }
        //public DbSet<PaymentMethod> PaymentMethods { get; set; }
        //public DbSet<BankAccount> BankAccounts { get; set; }





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


            modelBuilder.Entity<Employee>(builder =>
            {
                builder.HasKey(e => e.ID);

                builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(60);

                builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60);

                builder.Property(e => e.Address)
                    .HasMaxLength(250);




            });
        }
    }
}
