using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponseDto>> GetAllAsync();

    Task<ClientResponseDto> GetAsync(int id);
    
    Task<ClientResponseDto> CreateAsync(ClientRequestDto request);
}
