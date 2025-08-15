using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Controllers;

public class ClientGroupControllerMapper : Profile
{
    public ClientGroupControllerMapper()
    {
        CreateMap<ClientGroup, ClientGroupsResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount));
    }
}
