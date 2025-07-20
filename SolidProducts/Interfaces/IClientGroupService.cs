using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IClientGroupService
{
    Task<IEnumerable<ClientGroupsResponseDto>> GetAllAsync();
}
