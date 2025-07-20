using SolidProducts.DTOs;

namespace SolidProducts.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    }
}
