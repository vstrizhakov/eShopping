﻿using eShop.Messaging;
using eShop.Messaging.Contracts.Catalog;
using eShop.Messaging.Contracts.Distribution;
using eShop.Viber.Models;
using eShop.Viber.Services;
using eShop.Viber.ViberBotFramework.Views;
using eShop.ViberBot.Framework;
using eShop.ViberBot.Framework.Attributes;
using eShop.ViberBot.Framework.Contexts;
using MassTransit;

namespace eShop.Viber.ViberBotFramework.Controllers
{
    [ViberController]
    public class CurrencyController
    {
        private readonly IViberService _viberService;
        private readonly IRequestClient<GetPreferredCurrencyRequest> _getPreferredCurrencyRequestClient;
        private readonly IRequestClient<SetPreferredCurrencyRequest> _setPreferredCurrencyRequestClient;
        private readonly IRequestClient<GetCurrenciesRequest> _getCurrenciesRequestClient;

        public CurrencyController(
            IViberService viberService,
            IRequestClient<GetPreferredCurrencyRequest> getPreferredCurrencyRequestClient,
            IRequestClient<SetPreferredCurrencyRequest> setPreferredCurrencyRequestClient,
            IRequestClient<GetCurrenciesRequest> getCurrenciesRequestClient)
        {
            _viberService = viberService;
            _getPreferredCurrencyRequestClient = getPreferredCurrencyRequestClient;
            _setPreferredCurrencyRequestClient = setPreferredCurrencyRequestClient;
            _getCurrenciesRequestClient = getCurrenciesRequestClient;
        }

        [TextMessage(Action = ViberAction.CurrencySettings)]
        public async Task<IViberView?> CurrencySettings(TextMessageContext context)
        {
            var user = await _viberService.GetUserByIdAsync(context.UserId);
            if (user!.AccountId != null)
            {
                var request = new GetPreferredCurrencyRequest(user.AccountId.Value);
                var result = await _getPreferredCurrencyRequestClient.GetResponse<GetPreferredCurrencyResponse>(request);
                var response = result.Message;

                return new CurrencySettingsView(user.ExternalId, response.PreferredCurrency);
            }

            return null;
        }

        [TextMessage(Action = ViberAction.PreferredCurrencySettings)]
        public async Task<IViberView?> PreferredCurrencySettings(TextMessageContext context)
        {
            var user = await _viberService.GetUserByIdAsync(context.UserId);
            if (user!.AccountId != null)
            {
                var request = new GetCurrenciesRequest(user.AccountId.Value);
                var result = await _getCurrenciesRequestClient.GetResponse<GetCurrenciesResponse>(request);
                var response = result.Message;

                return new PreferredCurrencySettingsView(user.ExternalId, response.Currencies);
            }

            return null;
        }

        [TextMessage(Action = ViberAction.SetPreferredCurrency)]
        public async Task<IViberView?> SetPreferredCurrency(TextMessageContext context, Guid currencyId)
        {
            var user = await _viberService.GetUserByIdAsync(context.UserId);
            if (user!.AccountId != null)
            {
                var request = new SetPreferredCurrencyRequest(user.AccountId.Value, currencyId);
                var result = await _setPreferredCurrencyRequestClient.GetResponse<SetPreferredCurrencyResponse>(request);
                var response = result.Message;

                return new CurrencySettingsView(user.ExternalId, response.PreferredCurrency);
            }

            return null;
        }
    }
}
