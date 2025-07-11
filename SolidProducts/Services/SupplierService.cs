using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SupplierService(IUnitOfWork uow, IMapper mapper)
    {
        _unitOfWork = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierResponseDto>> GetAllAsync()
    {
        return await _unitOfWork.Suppliers
           .Query()
           .ProjectTo<SupplierResponseDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }
}
