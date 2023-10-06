﻿using eShop.Messaging.Models;
using eShop.Messaging.Models.Distribution;
using eShop.Telegram.Models;
using eShop.TelegramFramework;
using eShop.TelegramFramework.Builders;
using eShop.TelegramFramework.UI;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace eShop.Telegram.TelegramFramework.Views
{
    public class CurrencyRatesSettingsView : ITelegramView
    {
        private readonly long _chatId;
        private readonly Currency _preferredCurrency;
        private readonly IEnumerable<CurrencyRate> _currencyRates;

        public CurrencyRatesSettingsView(long chatId, Currency preferredCurrency, IEnumerable<CurrencyRate> currencyRates)
        {
            _chatId = chatId;
            _preferredCurrency = preferredCurrency;
            _currencyRates = currencyRates;
        }

        public async Task ProcessAsync(ITelegramBotClient botClient, IInlineKeyboardMarkupBuilder markupBuilder)
        {
            var text = $"Поточний курс валют відносно {_preferredCurrency.Name}\n\nНатисніть на валюту зі списку нижче, щоб змінити її курс.";

            var elements = _currencyRates.Select<CurrencyRate, IInlineKeyboardElement>(currencyRate =>
            {
                var currency = currencyRate.Currency;

                var buttonText = $"{currency.Name}: {currencyRate.Rate}";
                var element = new InlineKeyboardAction(buttonText, TelegramAction.SetCurrencyRate, currency.Id.ToString());
                return element;
            });
            var control = new InlineKeyboardList(elements)
            {
                Navigation = new InlineKeyboardAction("Назад", TelegramAction.CurrencySettings),
            };

            var replyMarkup = markupBuilder.Build(control);
            await botClient.SendTextMessageAsync(new ChatId(_chatId), text, replyMarkup: replyMarkup);
        }
    }
}
