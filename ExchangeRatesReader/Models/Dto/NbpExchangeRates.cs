using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Models.Dto
{
    public class NbpExchangeRates
    {
        public string Table { get; set; }
        public string No { get; set; }
        public DateTime EffectiveDate { get; set; }

        public List<NbpRate> Rates { get; set; }
    }
}
