using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Controllers;

public class InvoiceControllerMapper : Profile
{
    public InvoiceControllerMapper()
    {
        CreateMap<InvoiceRequestDto, Invoice>();
        // CreateMap<ClientRequest, Client>();
        CreateMap<InvoiceDetailRequest, InvoiceDetail>()
            .ForMember(dest => dest.Product, opt => opt.Ignore());

        CreateMap<Invoice, InvoiceResponseDto>();
        CreateMap<InvoiceDetail, InvoiceDetailResponse>();
        CreateMap<Client, ClientResponseDto>();
        CreateMap<PaymentCondition, PaymentConditionResponseDto>();
        CreateMap<Product, ProductResponseDto>();
    }
}