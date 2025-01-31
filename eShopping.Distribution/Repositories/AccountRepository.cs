﻿using eShopping.Distribution.Entities;
using eShopping.Database.Extensions;
using eShopping.Distribution.DbContexts;
using eShopping.Distribution.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopping.Distribution.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DistributionDbContext _context;

        public AccountRepository(DistributionDbContext context)
        {
            _context = context;
        }

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);

            await _context.SaveChangesAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(Guid id, Guid? announcerId = null)
        {
            var query = _context.Accounts
                .WithDiscriminatorAsPartitionKey()
                .Where(e => e.Id == id);

            if (announcerId.HasValue)
            {
                query = query.Where(e => e.AnnouncerId == announcerId.Value);
            }

            var account = await query.FirstOrDefaultAsync();
            return account;
        }

        public async Task<Account?> GetAccountByTelegramUserIdAsync(Guid telegramUserId)
        {
            var account = await _context.Accounts
                .WithDiscriminatorAsPartitionKey()
                .Where(e => e.TelegramUserId == telegramUserId)
                .FirstOrDefaultAsync();

            return account;
        }

        public async Task<Account?> GetViberByTelegramUserIdAsync(Guid viberUserId)
        {
            var account = await _context.Accounts
                .WithDiscriminatorAsPartitionKey()
                .Where(e => e.ViberUserId == viberUserId)
                .FirstOrDefaultAsync();

            return account;
        }

        public async Task<IEnumerable<Account>> GetAccountsByAnnouncerIdAsync(Guid announcerId, bool? isActivated = null, bool includeDistributionSettings = false)
        {
            var query = _context.Accounts
                .WithDiscriminatorAsPartitionKey()
                .Where(e => e.AnnouncerId == announcerId);

            if (isActivated.HasValue)
            {
                query = query.Where(e => e.IsActivated == isActivated.Value);
            }

            var accounts = await query.ToListAsync();
            return accounts;
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIsActivatedAsync(Account clientAccount, bool isActivated)
        {
            clientAccount.IsActivated = isActivated;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTelegramChatAsync(Account account, Guid telegramChatId, bool isEnabled)
        {
            var telegramChats = account.TelegramChats;
            var telegramChat = telegramChats.FirstOrDefault(e => e.Id == telegramChatId);
            if (telegramChat == null)
            {
                telegramChat = new TelegramChat
                {
                    Id = telegramChatId,
                };

                telegramChats.Add(telegramChat);
            }

            telegramChat.IsEnabled = isEnabled;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateViberChatAsync(Account account, Guid viberUserId, bool isEnabled)
        {
            var viberChat = account.ViberChat;
            if (viberChat == null)
            {
                viberChat = new ViberChat
                {
                    Id = viberUserId,
                };

                account.ViberChat = viberChat;
            }

            viberChat.IsEnabled = isEnabled;

            await _context.SaveChangesAsync();
        }
    }
}
