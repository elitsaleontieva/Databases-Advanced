namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PatientMedicamentConfiguration : IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> builder)
        {
            builder.HasKey(e =>
            new {
                e.MedicamentId,
                e.PatientId
            });


            builder.HasOne(e => e.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pi => pi.PatientId);

            builder.HasOne(e => e.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(f => f.MedicamentId);

        }
    }
}
