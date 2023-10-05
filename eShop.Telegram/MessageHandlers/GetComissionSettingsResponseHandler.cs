﻿using eShop.Bots.Common;
using eShop.Messaging;
using eShop.Messaging.Models.Distribution;
using eShop.Telegram.Services;
using eShop.Telegram.TelegramFramework.Views;
using Telegram.Bot;

namespace eShop.Telegram.MessageHandlers
{
    public class GetComissionSettingsResponseHandler : IMessageHandler<GetComissionSettingsResponse>
    {
        private readonly ITelegramService _telegramService;
        private readonly ITelegramBotClient _botClient;
        private readonly IBotContextConverter _botContextConverter;

        public GetComissionSettingsResponseHandler(ITelegramService telegramService, ITelegramBotClient botClient, IBotContextConverter botContextConverter)
        {
            _telegramService = telegramService;
            _botClient = botClient;
            _botContextConverter = botContextConverter;
        }

        public async Task HandleMessageAsync(GetComissionSettingsResponse message)
        {
            var user = await _telegramService.GetUserByAccountIdAsync(message.AccountId);
            if (user != null)
            {
                var telegramView = new ComissionSettingsView(user.ExternalId, message.Show, message.Amount);
                await telegramView.ProcessAsync(_botClient, _botContextConverter);
            }
        }
    }
}