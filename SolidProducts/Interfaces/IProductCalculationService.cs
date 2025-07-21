using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IProductCalculationService
{
    Task<ProductCalculationResponseDto> GetCalculatedProductAsync(ProductCalculationRequestDto request);
}
