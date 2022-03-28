using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRatesReader.Db;
using ExchangeRatesReader.Models.Dto;
using ExchangeRatesReader.Models.Entities;
using ExchangeRatesReader.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExchangeRatesReader.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatesController : ControllerBase
    {

        private readonly IRatesService _ratesService;

        public RatesController(IRatesService exchangeRatesProvider)
        {
            _ratesService = exchangeRatesProvider;
        }

        [HttpGet]
        public IEnumerable<RateDto> Get()
        {
            return _ratesService.GetLatest();
        }

        [HttpPost]
        public async Task<IEnumerable<RateDto>> DownloadLatest()
        {
            await _ratesService.DownloadLatestRates();

            return _ratesService.GetLatest();
        }
    }
}
