using AutoMapper;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;
using SolidProducts.Util;

namespace SolidProducts.Services;

public class ProductCalculationService : IProductCalculationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClientService _clientService;
    private readonly IProductService _productService;

    public ProductCalculationService(IUnitOfWork uow, IMapper mapper, IClientService clientService, IProductService productService)
    {
        _unitOfWork = uow;
        _mapper = mapper;
        _clientService = clientService;
        _productService = productService;
    }

    public async Task<ProductCalculationResponseDto> GetCalculatedProductAsync(ProductCalculationRequestDto request)
    {
        var responseClient = await _clientService.GetAsync(request.ClientId);

        var responseProduct = await _productService.GetAsync(request.ProductId);

        return Calculations.CalculationProduct(responseClient, responseProduct, request.Quantity);
    }
}
