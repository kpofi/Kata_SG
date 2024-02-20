using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Repository
{
    public interface IBalanceRepository
    {
        Balance GetCurrentBalance();
    }
}
