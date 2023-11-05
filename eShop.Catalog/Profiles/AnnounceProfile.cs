﻿using AutoMapper;
using eShop.Catalog.Models.Announces;

namespace eShop.Catalog.Profiles
{
    public class AnnounceProfile : Profile
    {
        public AnnounceProfile()
        {
            CreateMap<CreateAnnounceRequest, Entities.Announce>()
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.OwnerId, options => options.Ignore())
                .ForMember(dest => dest.CreatedAt, options => options.Ignore())
                .ForMember(dest => dest.DistributionId, options => options.Ignore())
                .ForMember(dest => dest.Images, options => options.Ignore())
                .ForMember(dest => dest.Shop, options => options.Ignore());
            CreateMap<Entities.Announce, Announce>()
                .ForMember(dest => dest.Images, options => options.MapFrom(src => src.Images.Select(image => image.Path)));
        }
    }
}