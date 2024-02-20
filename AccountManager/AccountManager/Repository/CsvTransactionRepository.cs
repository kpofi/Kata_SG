using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Repository
{
    public class CsvTransactionRepository : ITransactionRepository
    {
        public IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to)
        {
            string filePath = "Data/account.csv";
            var lines = File.ReadAllLines(filePath);

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            var transactions = lines.Skip(4).Select(line =>
            {
                string[] parts = line.Split(';');
                return new Transaction
                {
                    TransactionDate = DateTime.ParseExact(parts[0], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TransactionAmount = decimal.Parse(parts[1], NumberStyles.Number, culture),
                    TranactionCurrency = parts[2],
                    TransactionCategory = parts[3]
                };
            }).Where(t => t.TransactionDate >= from && t.TransactionDate <= to).ToList();

            return transactions;
        }
    }
}
