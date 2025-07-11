using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IManufacturerService
{
    Task<IEnumerable<ManufacturerResponseDto>> GetAllAsync();
}
