using SolidProducts.DTOs;

namespace SolidProducts.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    }
}
