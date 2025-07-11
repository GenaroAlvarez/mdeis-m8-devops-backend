using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IProductGroupService
{
    Task<IEnumerable<ProductGroupsResponseDto>> GetAllAsync();
}
