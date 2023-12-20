﻿using eShop.Catalog.Repositories;
using eShop.Catalog.Entities;

namespace eShop.Catalog.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync(IEnumerable<Guid> currencyIds)
        {
            var currencies = await _currencyRepository.GetCurrenciesAsync(currencyIds);
            return currencies;
        }
    }
}
