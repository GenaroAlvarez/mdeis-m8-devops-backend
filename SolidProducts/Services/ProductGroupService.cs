using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class ProductGroupService : IProductGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductGroupService(IUnitOfWork uow, IMapper mapper)
    {
        _unitOfWork = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductGroupsResponseDto>> GetAllAsync()
    {
        return await _unitOfWork.ProductGroups
           .Query()
           .ProjectTo<ProductGroupsResponseDto>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }
}
