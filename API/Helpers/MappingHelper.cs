using API.Dto;
using AutoMapper;
using Core.Models;
using Core.Models.Identity;
using Core.Models.OrderAggregate;

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
            CreateMap<Core.Models.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<AddressDto, Core.Models.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }  
    }
}
