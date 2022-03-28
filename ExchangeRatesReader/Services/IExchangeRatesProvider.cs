using ExchangeRatesReader.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Services
{
    public interface IExchangeRatesProvider
    {
        Task<List<Rate>> GetLatestRatesAsync();


    }
}
