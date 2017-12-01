namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.PatientId);

            builder.Property(e => e.FirstName)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(e => e.Address)
                .IsUnicode()
                .HasMaxLength(250);

            builder.Property(e => e.Email)
                .IsUnicode(false)
                .HasMaxLength(80);

            
            



        }
    }
}
