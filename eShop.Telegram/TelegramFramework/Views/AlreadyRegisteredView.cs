﻿using eShop.Bots.Common;
using eShop.TelegramFramework;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace eShop.Telegram.TelegramFramework.Views
{
    public class AlreadyRegisteredView : ITelegramView
    {
        private readonly long _chatId;

        public AlreadyRegisteredView(long chatId)
        {
            _chatId = chatId;
        }

        public async Task ProcessAsync(ITelegramBotClient botClient, IBotContextConverter botContextConverter)
        {
            await botClient.SendTextMessageAsync(new ChatId(_chatId), "Ви вже зареєстровані та маєтє встановленного постачальника анонсів");
        }
    }
}