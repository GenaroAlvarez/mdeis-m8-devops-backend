using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientService(IUnitOfWork uow, IMapper mapper)
    {
        _unitOfWork = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientResponseDto>> GetAllAsync()
    {
        return await _unitOfWork.Clients
           .Query()
           .ProjectTo<ClientResponseDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }

    public async Task<ClientResponseDto> GetAsync(int id)
    {
        return await _unitOfWork.Clients
           .Query()
           .Where(x => x.Id == id)
           .ProjectTo<ClientResponseDto>(_mapper.ConfigurationProvider)
           .FirstAsync();
    }

    public async Task<ClientResponseDto> CreateAsync(ClientRequestDto request)
    {
        var client = _mapper.Map<Client>(request);
        var created = await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<ClientResponseDto>(created);
    }
}
