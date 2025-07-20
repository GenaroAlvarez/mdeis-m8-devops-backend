using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class ClientGroupService(IUnitOfWork uow, IMapper mapper) : IClientGroupService
{
    private readonly IUnitOfWork _unitOfWork = uow;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClientGroupsResponseDto>> GetAllAsync()
    {
        return await _unitOfWork.ClientGroups
           .Query()
           .ProjectTo<ClientGroupsResponseDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }
}
