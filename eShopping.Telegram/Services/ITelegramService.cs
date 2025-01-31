﻿using eShopping.Telegram.Entities;

namespace eShopping.Telegram.Services
{
    public interface ITelegramService
    {
        Task<TelegramUser?> GetUserByExternalIdAsync(long externalId);
        Task<IEnumerable<TelegramChat>> GetManagableChats(TelegramUser user);
        Task UpdateUserAsync(TelegramUser user);
        Task<TelegramUser?> GetUserByAccountIdAsync(Guid accountId);
        Task<TelegramUser?> GetUserByTelegramUserIdAsync(Guid telegramUserId);
        Task SetAccountIdAsync(TelegramUser user, Guid accountId);
        Task SetActiveContextAsync(TelegramUser user, string? context);
    }
}
