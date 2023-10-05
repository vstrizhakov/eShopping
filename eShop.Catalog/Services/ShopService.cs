﻿using eShop.Catalog.Entities;
using eShop.Catalog.Repositories;

namespace eShop.Catalog.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<IEnumerable<Shop>> GetShopsAsync()
        {
            var shops = await _shopRepository.GetShopsAsync();
            return shops;
        }
    }
}