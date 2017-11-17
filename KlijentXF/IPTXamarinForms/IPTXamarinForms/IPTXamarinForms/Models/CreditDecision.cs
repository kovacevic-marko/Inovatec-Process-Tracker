using System;

namespace IPTXamarinForms.Models
{
    public class CreditDecision
    {
        public string tier { get; set; }
        public string ProgramName { get; set; }
        public string DecStatus { get; set; }
        public Nullable<System.DateTime> DecDateTime { get; set; }
        public string LenderComments { get; set; }
        public Nullable<float> Amount { get; set; }
        public Nullable<float> InterestRate { get; set; }
        public Nullable<int> Term { get; set; }
        public Nullable<int> Amortization { get; set; }
        public Nullable<float> TotalMthPay { get; set; }
        public string PaymentFrequency { get; set; }
        public Nullable<System.DateTime> FirstPaymentDate { get; set; }
        public Nullable<float> CashDown { get; set; }
    }
}
