﻿namespace eShopping.Distribution.Models.Distributions
{
    public class DistributionItem
    {
        public Guid Id { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public Guid? ViberChatId { get; set; }
        public Guid? TelegramChatId { get; set; }
    }
}