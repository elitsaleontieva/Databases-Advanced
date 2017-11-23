namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
 

           builder
            .Ignore(e => e.LimitLeft);

            builder
            .Ignore(e => e.PaymentMethodId);

        }
    }
}
