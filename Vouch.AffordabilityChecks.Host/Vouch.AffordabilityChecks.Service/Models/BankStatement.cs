using System;
namespace Vouch.AffordabilityChecks.Service.Models
{
    public class BankStatement
    {
        public DateTime Date { get; set; }
        public int Month { get; set; }
        public string PaymentType { get; set; }
        public string Details { get; set; }
        public double MoneyIn { get; set; }
        public double MoneyOut { get; set; }
        public double Balance { get; set; }
    }
}
