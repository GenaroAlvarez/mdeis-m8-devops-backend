using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponseDto>> GetAllAsync();
}
