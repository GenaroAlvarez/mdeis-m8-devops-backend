using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Controllers;

public class InvoiceControllerMapper : Profile
{
    public InvoiceControllerMapper()
    {
        CreateMap<InvoiceRequestDto, Invoice>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.Id))
            .ForMember(dest => dest.Client, opt => opt.Ignore())
            .ForMember(dest => dest.PaymentCondition, opt => opt.Ignore())
            .ForMember(dest => dest.PaymentConditionId, opt => opt.MapFrom(src => src.PaymentCondition.Id));
        // CreateMap<ClientRequest, Client>();
        CreateMap<InvoiceDetailRequest, InvoiceDetail>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Product, opt => opt.Ignore())
            .ForMember(dest => dest.Invoice, opt => opt.Ignore())
            .ForMember(dest => dest.Warehouse, opt => opt.Ignore());
        // CreateMap<PaymentConditionRequest, PaymentCondition>();
        // CreateMap<ClientRequest, Client>();
        // .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.BusinessName))
        // .ForMember(dest => dest.Nit, opt => opt.MapFrom(src => src.Nit))
        // .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
        // .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
        // .ForMember(dest => dest.PaymentCondition, opt => opt.MapFrom(src => src.PaymentCondition));
    }
}