using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TranactionCurrency { get; set; } = "EUR";
        public string TransactionCategory { get; set; } = string.Empty;
    }
}
