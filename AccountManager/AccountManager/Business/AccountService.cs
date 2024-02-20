using AccountManager.DataAccessLayer;
using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Business
{
    public class AccountService
    {
        private readonly TransactionDal _transactionDal;
        private readonly BalanceDal _balanceDal;
        private readonly FxRateDal _fxRateDal;

        public AccountService(TransactionDal transactionDal, BalanceDal balanceDal, FxRateDal fxRateDal) 
        { 
            _transactionDal = transactionDal;
            _balanceDal = balanceDal;
            _fxRateDal = fxRateDal;
        }

        public IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to)
        {
            return _transactionDal.GetTransactions(from, to);
        }

        public decimal ComputeBalanceAt(DateTime date)
        {
            var currentBalance = _balanceDal.GetCurrentBalance();
            var jpyFxRate = _fxRateDal.GetFxRate("JPY");
            var usdFxRate = _fxRateDal.GetFxRate("USD");

            var transactionsByCurrency = _transactionDal.GetTransactions(date, currentBalance.BalanceDate)
                .GroupBy(t => t.TranactionCurrency);

            var totalTransaction = 0m;

            foreach (var transactions in transactionsByCurrency)
            {
                var tansactionAmountEur = transactions.Sum(t => t.TransactionAmount);

                if (transactions.Key == "JPY")
                {
                    tansactionAmountEur *= jpyFxRate.Rate;
                }
                if (transactions.Key == "USD")
                {
                    tansactionAmountEur *= usdFxRate.Rate;
                }

                totalTransaction += tansactionAmountEur;
            }

            return currentBalance.BalanceValue - totalTransaction;
        }
    }
}
