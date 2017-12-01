
namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DiagnosesConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(e => e.DiagnoseId);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(e => e.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            builder.HasOne(e => e.Patient)
                .WithMany(d => d.Diagnoses)
                .HasForeignKey(f => f.PatientId);
        }
    }

}
