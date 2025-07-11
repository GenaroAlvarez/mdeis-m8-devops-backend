using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Controllers;

public class ManufacturerControllerMapper : Profile
{
    public ManufacturerControllerMapper()
    {
        CreateMap<Manufacturer, ManufacturerResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
