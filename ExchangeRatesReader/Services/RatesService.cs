using ExchangeRatesReader.Db;
using ExchangeRatesReader.Models.Dto;
using ExchangeRatesReader.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Services
{
    public class RatesService : IRatesService
    {

        private readonly IExchangeRatesProvider _exchangeRatesProvider;

        private readonly RatesDbContext _db;

        public RatesService(IExchangeRatesProvider exchangeRatesProvider, RatesDbContext dbContext)
        {
            _exchangeRatesProvider = exchangeRatesProvider;
            _db = dbContext;
        }


        public async Task DownloadLatestRates()
        {
            var rates = await _exchangeRatesProvider.GetLatestRatesAsync();

            SynchronizeCurrencies(rates);
            SaveRates(rates);
        }

        public IEnumerable<RateDto> GetLatest()
        {
            var rates = _db.Rates.Include(x => x.Currency).ToList();

            var latest = rates.GroupBy(x => x.Currency.Id)
                .Select(currencyGroup => currencyGroup.OrderByDescending(x => x.Date).First());

            return latest.Select(x =>
                new RateDto
                {
                    CurrencyCode = x.Currency.Code,
                    CurrencyName = x.Currency.Name,
                    Value = x.Value,
                    Date = x.Date
                }
            )
                .OrderBy(x=> x.Date)
                .ThenBy(x=> x.CurrencyCode)
                .ToList();
        }

        private void SynchronizeCurrencies(List<Rate> rates)
        {
            var existingCurrencies = _db.Currencies.ToDictionary(x=> x.Code.ToUpper());

            foreach (var rate in rates)
            {
                var code = rate.Currency.Code.ToUpper();

                if (existingCurrencies.ContainsKey(code))
                {
                    rate.Currency = existingCurrencies[code];
                }
            }
        }

        private void SaveRates(List<Rate> rates)
        {
            //assuming that rates are published once a day, so no more than one rate for a day is saved

            var existingRates = _db.Rates.Include(x=> x.Currency).ToList();
            var toAdd = new List<Rate>();

            foreach (var rate in rates)
            {
                var rateAlreadyExists = existingRates.Any(x => x.Date.Date == rate.Date.Date && x.Currency.Code.Equals(rate.Currency.Code, StringComparison.InvariantCultureIgnoreCase));

                if (rateAlreadyExists == false)
                {
                    toAdd.Add(rate);
                }
            }

            _db.AddRange(toAdd);
            _db.SaveChanges();
        }
    }
}
