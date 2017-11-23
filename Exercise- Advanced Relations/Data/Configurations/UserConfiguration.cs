namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.FirstName)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(50);

            builder.Property(e => e.LastName)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(50);

            builder.Property(e => e.Email)
            .IsUnicode(false)
            .HasMaxLength(80);

            builder.Property(e => e.Password)
           .IsUnicode(false)
           .HasMaxLength(25);
        }
    }
}
