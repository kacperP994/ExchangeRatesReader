using ExchangeRatesReader.Models.Dto;
using ExchangeRatesReader.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Services
{
    public class NBPExchangeRatesProvider : IExchangeRatesProvider
    {
        private readonly HttpClient _client;

        //todo logger do logowania bledow z api gdy status nieok
        //format json wyniesc do startup albo i nie

        public NBPExchangeRatesProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Rate>> GetLatestRatesAsync()
        {
            var response = await _client.GetAsync("exchangerates/tables/A/?format=json");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return ParseRatesResponse(content);
            }


            throw new NotImplementedException();
        }

        public List<Rate> ParseRatesResponse(string content)
        {
            //array type is returned, but in latest rates query it should have one element 
            var ratesDto = JsonConvert.DeserializeObject<NbpExchangeRates[]>(content)[0];

            var rates = ratesDto.Rates
                .Select(x => new Rate
                {
                    Date = ratesDto.EffectiveDate,
                    Value = x.Mid,
                    Currency = new Currency
                    {
                        Code = x.Code,
                        Name = x.Currency,
                    }
                })
                .ToList();

            return rates;
        }
    }
}
