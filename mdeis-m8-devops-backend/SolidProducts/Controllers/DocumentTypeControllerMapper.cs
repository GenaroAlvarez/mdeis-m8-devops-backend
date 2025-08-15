using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

public class DocumentTypeControllerMapper : Profile
{
    public DocumentTypeControllerMapper()
    {
        CreateMap<DocumentType, DocumentTypeResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code));
    }
}