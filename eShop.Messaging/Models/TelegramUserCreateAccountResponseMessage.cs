﻿namespace eShop.Messaging.Models
{
    public class TelegramUserCreateAccountResponseMessage
    {
        public Guid TelegramUserId { get; set; }
        public Guid AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ProviderId { get; set; }
        public string ProviderEmail { get; set; }
    }
}
