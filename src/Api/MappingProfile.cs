using AutoMapper;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Entities;
using Domain.Models;

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
//CreateOrderRequest mappings
        CreateMap<CreateOrderRequest, OrderEntity>()
            .ForMember(dest => dest.CreationDateTime, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<ProductRequest, ProductEntity>();
        CreateMap<OrderEntity, CreateOrderResponse>();
        CreateMap<ProductEntity, ProductResponse>()
            .ForMember(dest => dest.ProductTypeTitle, opt => opt.MapFrom(src => src.ProductType.Title));

//GetOrderResponse mappings
        CreateMap<Order, GetOrderResponse>();
        CreateMap<ProductTypeEntity, ProductType>();
        CreateMap<ProductEntity, Product>();
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.ProductTypeTitle, opt => opt.MapFrom(src => src.Type.Title));
        CreateMap<OrderEntity, Order>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ForMember(dest => dest.Package, opt => opt.MapFrom(src =>
                    Package(src.Products)
                //src.Products
            )).ReverseMap();
    }

    private Package Package(IEnumerable<ProductEntity> products)
    {
        var items = products
            .GroupBy(productEntity => productEntity.ProductType)
            .Select(entities => new PackageItem(entities.Key, entities.Sum(p => p.Quantity))).ToList();
        return new Package(Items: items, Width: items.Sum(i => i.Width));
    }
}