﻿using eShop.Telegram.Entities;

namespace eShop.Telegram.Repositories
{
    public interface ITelegramUserRepository
    {
        Task CreateTelegramUserAsync(TelegramUser telegramUser);
        Task<TelegramUser?> GetTelegramUserByExternalIdAsync(long externalId);
        Task<TelegramUser?> GetTelegramUserByIdAsync(Guid id);
        Task UpdateAccountIdAsync(TelegramUser telegramUser, Guid accountId);
        Task UpdateTelegramUserAsync(TelegramUser telegramUser);
    }
}