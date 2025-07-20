using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Controllers;

public class ProductControllerMapper : Profile
{
    public ProductControllerMapper()
    {
        //CreateMap<ProductRequestDto, Product>();

        CreateMap<Product, ProductResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.ProductGroup, opt => opt.MapFrom(src => src.ProductGroup));
    }
    
}
