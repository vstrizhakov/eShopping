﻿using AutoMapper;
using eShopping.Messaging.Contracts.Catalog;
using eShopping.Catalog.Repositories;
using eShopping.Messaging.Contracts;
using eShopping.Messaging.Contracts.Catalog;
using MassTransit;

namespace eShopping.Catalog.Consumers
{
    public class GetCurrenciesRequestHandler : IConsumer<GetCurrenciesRequest>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public GetCurrenciesRequestHandler(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<GetCurrenciesRequest> context)
        {
            var request = context.Message;

            var currencies = await _currencyRepository.GetCurrenciesAsync();
            var mappedCurrencies = _mapper.Map<IEnumerable<Currency>>(currencies);

            var response = new GetCurrenciesResponse(request.AccountId, mappedCurrencies);
            await context.RespondAsync(response);
        }
    }

}
