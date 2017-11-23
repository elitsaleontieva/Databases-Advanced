namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new
            {
                e.UserId,
                e.BankAccountId,
                e.CreditCardId
            })
            .IsUnique();
            //Make sure that every record in the PaymentMethods 
            //table has a unique combination of UserId, BankAccountId and CreditCardId!


            //collection in users
            builder.HasOne(e => e.User)
                .WithMany(m => m.PaymentMethods)
                .HasForeignKey(f => f.UserId);

            //NO collection in creditcards -ONE TO ONE
            builder.HasOne(e => e.CreditCard)
               .WithOne(m => m.PaymentMethod)
               .HasForeignKey<CreditCard>(f => f.CreditCardId);

            // NO collection in bankaccounts -ONE TO ONE
            builder.HasOne(e => e.BankAccount)
              .WithOne(m => m.PaymentMethod)
              .HasForeignKey<BankAccount>(f => f.BankAccountId);


            

        }
    }
}
