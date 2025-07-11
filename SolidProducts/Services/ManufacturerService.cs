using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ManufacturerService(IUnitOfWork uow, IMapper mapper)
    {
        _unitOfWork = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ManufacturerResponseDto>> GetAllAsync()
    {
        return await _unitOfWork.Manufacturers
           .Query()
           .ProjectTo<ManufacturerResponseDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }
}
