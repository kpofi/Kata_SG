using AccountManager.Models;
using AccountManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DataAccessLayer
{
    public class TransactionDal
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionDal(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetTransactions(DateTime from, DateTime to)
        {
            return _transactionRepository.GetTransactions(from, to);
        }
    }
}
