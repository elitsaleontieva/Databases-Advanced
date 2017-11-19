﻿
namespace P03_SalesDatabase.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;


    class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

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
            modelBuilder.Entity<Product>(entity =>
            {

                entity.HasKey(e => e.ProductId);


                entity.Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(50);

                //price
                //sales

            });

            modelBuilder.Entity<Customer>(entity =>
            {

                entity.HasKey(e => e.CustomerId);


                entity.Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(100);

                entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasMaxLength(80);

                //sales


            });

            modelBuilder.Entity<Store>(entity =>
            {

                entity.HasKey(e => e.StoreId);


                entity.Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(80);


                //sales

            });


            modelBuilder.Entity<Sale>(entity =>
            {

                entity.HasKey(e => e.SaleId);

                entity.HasOne(e => e.Product)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(e => e.ProductId);

                entity.HasOne(e => e.Customer)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(e => e.CustomerId);

                entity.HasOne(e => e.Store)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(e => e.StoreId);
                //	Product
                //	Customer
                //	Store


            });

        }
    }
}

