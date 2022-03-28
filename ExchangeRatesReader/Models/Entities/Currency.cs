using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Models.Entities
{
    public class Currency : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }
}
