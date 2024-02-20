using AccountManager.Models;
using AccountManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DataAccessLayer
{
    public class FxRateDal
    {
        private readonly IFxRateRepository _fxRateRepository;

        public FxRateDal(IFxRateRepository fxRateRepository)
        {
            _fxRateRepository = fxRateRepository;
        }

        public FxRate GetFxRate(string currency)
        {
            return _fxRateRepository.GetFxRate(currency);
        }
    }
}
