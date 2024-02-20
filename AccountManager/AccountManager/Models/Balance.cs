using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    public class Balance
    {
        public DateTime BalanceDate { get; set; }
        public decimal BalanceValue { get; set; }
        public string BalanceCurrency { get; set; } = "EUR";
    }
}
