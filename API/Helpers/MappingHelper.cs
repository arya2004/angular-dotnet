﻿using API.Dto;
using AutoMapper;
using Core.Models;

namespace API.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand,  o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom< ProductUrlResolver>());
        }
    }
}