﻿using AutoMapper;
using eShop.Messaging.Contracts.Catalog;

namespace eShop.Catalog.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Entities.EmbeddedShop, Models.Shops.Shop>();
            CreateMap<Entities.Shop, Models.Shops.Shop>();
            CreateMap<Entities.Shop, Shop>();
        }
    }
}
