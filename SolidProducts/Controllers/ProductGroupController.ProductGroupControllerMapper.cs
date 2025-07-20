// using AutoMapper;
// using SolidProducts.DTOs;
// using SolidProducts.Entities;

// namespace SolidProducts.Controllers;

// public class ProductGroupControllerMapper : Profile
// {
//     public ProductGroupControllerMapper()
//     {
//         CreateMap<ProductGroup, ProductGroupsResponseDto>()
//             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
//             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
//             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
//     }
// }
