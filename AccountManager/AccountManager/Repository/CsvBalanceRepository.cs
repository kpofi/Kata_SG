using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccountManager.Repository
{
    public class CsvBalanceRepository : IBalanceRepository
    {
        public Balance GetCurrentBalance()
        {
            string filePath = "Data/account.csv";
            string firstLine = File.ReadLines(filePath).First();

            Match match = Regex.Match(firstLine, @"\b\d{2}/\d{2}/\d{4}\b");

            var currentBalanceDate = DateTime.Today;

            if (match.Success)
            {
                if (DateTime.TryParseExact(match.Value, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var date))
                {
                    currentBalanceDate = date;
                }
            }

            var balanceValue = 0m;

            var index = firstLine.IndexOf(':');
            var accountBalance = firstLine.Substring(index + 1);
            match = Regex.Match(accountBalance, @"(\d+(\.\d+)?)");
            if (match.Success)
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                if (decimal.TryParse(match.Value, NumberStyles.Number, culture, out var amount)) 
                {
                    balanceValue = amount;
                }
            }

            var currentBalance = new Balance
            {
                BalanceDate = currentBalanceDate,
                BalanceValue = balanceValue
            };

            return currentBalance;
        }
    }
}
