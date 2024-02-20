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
    public class CsvFxRateRepository : IFxRateRepository
    {
        public FxRate GetFxRate(string currency)
        {
            string filePath = "Data/account.csv";

            var fxRate = new FxRate 
            { 
                Currency = currency,
                Rate = 1
            };

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    var line = sr.ReadLine();

                    for (int i = 0; i < 2;  i++)
                    {
                        line = sr.ReadLine();

                        if (line != null && line.Contains(currency))
                        {
                            Match match = Regex.Match(line, @"(\d+(\.\d+)?)");
                            if (match.Success)
                            {
                                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                                if (decimal.TryParse(match.Value, NumberStyles.Number, culture, out var rate))
                                {
                                    fxRate.Rate = rate;
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException($"Unable to get Fx Rate for {currency}");
            }

            return fxRate;
        }
    }
}
