using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Models.Entities
{
    public class Rate : BaseModel
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public Currency Currency { get; set; }
    }
}
