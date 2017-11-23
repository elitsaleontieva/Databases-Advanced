namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {

            builder.HasKey(e => e.BankAccountId);

           builder
            .Property(e => e.BankName)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(50);

            builder
           .Property(e => e.SwiftCode)
           .HasMaxLength(20)
           .IsUnicode(false);

            builder
          .Ignore(e => e.PaymentMethodId);
        }
    }
}
