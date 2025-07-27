using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Controllers;

public class ClientControllerMapper : Profile
{
    public ClientControllerMapper()
    {
        CreateMap<Client, ClientResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.DocumentNumber))
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType));
    }
}
