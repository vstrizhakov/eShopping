﻿namespace eShop.Messaging.Models.Viber
{
    public class RegisterViberUserRequest : Messaging.Message, IRequest<RegisterViberUserResponse>
    {
        public Guid ViberUserId { get; set; }
        public Guid ProviderId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}