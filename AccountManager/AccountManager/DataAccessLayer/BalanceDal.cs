using AccountManager.Models;
using AccountManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DataAccessLayer
{
    public class BalanceDal
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceDal(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public Balance GetCurrentBalance()
        {
            return _balanceRepository.GetCurrentBalance();
        }
    }
}
