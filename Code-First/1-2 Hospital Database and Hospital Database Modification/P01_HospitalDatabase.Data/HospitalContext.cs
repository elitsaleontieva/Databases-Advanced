

namespace P01_HospitalDatabase.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    using P01_HospitalDatabase.Data.EntityConfiguration;

    public class HospitalContext : DbContext
    {

            public HospitalContext()
            {

            }

            public HospitalContext(DbContextOptions options)
                : base(options)
            {

            }



        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }






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
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new VisitationConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnosesConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new PatientMedicamentConfiguration());




        }
    }
    }

