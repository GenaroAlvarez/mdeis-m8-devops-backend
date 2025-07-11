using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface ISupplierService
{
    Task<IEnumerable<SupplierResponseDto>> GetAllAsync();
}
