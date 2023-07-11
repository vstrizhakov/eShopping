﻿using eShop.Identity.Entities;
using eShop.Messaging;
using eShop.Messaging.Models;
using Microsoft.AspNetCore.Identity;

namespace eShop.Identity.MessageHandlers
{
    public class IdentityUserCreateAccountResponseMessageHandler : IMessageHandler<IdentityUserCreateAccountResponseMessage>
    {
        private readonly UserManager<User> _userManager;

        public IdentityUserCreateAccountResponseMessageHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task HandleMessageAsync(IdentityUserCreateAccountResponseMessage message)
        {
            var user = await _userManager.FindByIdAsync(message.IdentityUserId);
            if (user != null)
            {
                user.AccountId = message.AccountId;

                await _userManager.UpdateAsync(user);
            }
        }
    }
}