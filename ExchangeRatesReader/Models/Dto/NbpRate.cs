using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Models.Dto
{
    public class NbpRate
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public decimal Mid { get; set; }
    }
}
