
namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.MedicamentId);

            builder.Property(e => e.Name)
                .IsUnicode()
                .HasMaxLength(50);
        }
    }
}
