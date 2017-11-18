using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data //!!! add .Data
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

        //ако класовете са в друг проект трябва да ги направим public
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
                //не са задължителни!!! 

                //	PatientId
                entity.HasKey(e => e.PatientId);

                //FirstName (up to 50 characters, unicode)
                entity.Property(e => e.FirstName)
                .IsRequired(true) //по default е true
                .IsUnicode(true) //ако искаме да е Unicode - true; ако не искаме- false
                .HasMaxLength(50);

                //	LastName (up to 50 characters, unicode)
                entity.Property(e => e.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                //Address(up to 250 characters, unicode)
                entity.Property(e => e.Adress)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);

                //Email (up to 80 characters, not unicode)
                entity.Property(e => e.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);

                //	HasInsurance
                entity.Property(e => e.HasInsurance)
                .HasDefaultValue(true);
             


            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                //не са задължителни!!! 

                
                entity.HasKey(e => e.VisitationId);


                entity.Property(e => e.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Comments)
              .IsRequired(false)
              .IsUnicode(true)
              .HasMaxLength(255);

                //мапване
                entity.HasOne(e => e.Patient)
                .WithMany(p => p.Visitations) //много визитации
                .HasForeignKey(e => e.PatientId)
                .HasConstraintName("FK_Visitation_Patient"); //не е задължително
                //fk patientid
                

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
                .WithMany(p => p.Diagnoses) //много визитации
                .HasForeignKey(e => e.PatientId); 
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(50);

                //връзката я правим с маппинг таблицата -patientmedicaments
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                //composite key
                entity.HasKey(e => new { e.PatientId, e.MedicamentId});

                entity.HasOne(e => e.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(e=> e.MedicamentId);

                entity.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e=>e.PatientId);

                //връзката я правим с маппинг таблицата -patientmedicaments
            });
        }
    }
}
