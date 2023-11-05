﻿namespace eShop.Messaging.Models.Telegram
{
    public class RegisterTelegramUserRequest : Messaging.Message, IRequest<RegisterTelegramUserResponse>
    {
        public Guid TelegramUserId { get; set; }
        public Guid ProviderId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}