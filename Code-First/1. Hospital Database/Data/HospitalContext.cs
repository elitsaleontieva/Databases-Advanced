using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity => 
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.FirstName)
                .IsRequired(true) 
                .IsUnicode(true) 
                .HasMaxLength(50);
                
                entity.Property(e => e.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                entity.Property(e => e.Adress)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);

                entity.Property(e => e.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);

                entity.Property(e => e.HasInsurance)
                .HasDefaultValue(true);
             


            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                
                entity.HasKey(e => e.VisitationId);


                entity.Property(e => e.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Comments)
              .IsRequired(false)
              .IsUnicode(true)
              .HasMaxLength(255);

                entity.HasOne(e => e.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(e => e.PatientId)
                .HasConstraintName("FK_Visitation_Patient"); 
                

            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.Comments)
             .IsRequired(false)
             .IsUnicode(true)
             .HasMaxLength(255);
           

            entity.Property(e => e.Name)
           .IsRequired(true)
           .IsUnicode(true)
           .HasMaxLength(50);

            entity.HasOne(e => e.Patient)
            .WithMany(p => p.Diagnoses) 
            .HasForeignKey(e => e.PatientId); 
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(50);

            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.MedicamentId});

                entity.HasOne(e => e.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(e=> e.MedicamentId);

                entity.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e=>e.PatientId);

            });
        }
    }
}
