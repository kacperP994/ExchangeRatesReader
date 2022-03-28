using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Models.Dto
{
    public class RateDto
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
