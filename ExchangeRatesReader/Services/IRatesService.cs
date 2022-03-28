using ExchangeRatesReader.Models.Dto;
using ExchangeRatesReader.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Services
{
    public interface IRatesService
    {
        Task DownloadLatestRates();
        IEnumerable<RateDto> GetLatest();
    }
}
