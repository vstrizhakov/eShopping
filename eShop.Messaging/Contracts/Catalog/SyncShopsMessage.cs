﻿namespace eShop.Messaging.Contracts.Catalog
{
    public class SyncShopsMessage
    {
        public IEnumerable<Shop> Shops { get; set; }
    }
}
