using System;
using System.Collections.Generic;
namespace P01_BillsPaymentSystem.Data.Models
{
    using System.Text;

    public class CreditCard
    {


        public int CreditCardId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Limit { get; set; }

        public decimal LimitLeft => LimitLeft - MoneyOwed; ////o LimitLeft(calculated property, not included in the database)

        public decimal MoneyOwed { get; set; }

        public int PaymentMethodId { get; set; } //should not be in the database
        public PaymentMethod PaymentMethod { get; set; } //should not be in the database


    }
}
   