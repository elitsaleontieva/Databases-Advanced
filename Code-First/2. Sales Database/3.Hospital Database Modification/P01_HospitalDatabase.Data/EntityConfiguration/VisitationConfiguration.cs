namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder.HasKey(e => e.VisitationId);

            builder.Property(e => e.Comments)
                .IsUnicode()
                .HasMaxLength(250);


            builder.HasOne(e => e.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(f => f.PatientId);

            builder.HasOne(e => e.Doctor)
                .WithMany(v => v.Visitations)
                .HasForeignKey(f => f.DoctorId);
            
        }
    }
}
