using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        // public async Task<ProductResponseDto> CreateAsync(ProductRequestDto productRequestDto)
        // {
        //     var entity = _mapper.Map<Product>(productRequestDto);
        //     var created = await _unitOfWork.Products.AddAsync(entity);
        //     await _unitOfWork.CommitAsync();
        //     var product = _mapper.Map<ProductResponseDto>(created);
        //     return product;
        // }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            return await _unitOfWork.Products
               .Query()
               .ProjectTo<ProductResponseDto>(_mapper.ConfigurationProvider)
               .ToListAsync();
        }

        public async Task<ProductResponseDto> GetAsync(int id)
        {
            return await _unitOfWork.Products
               .Query()
               .Where(x => x.Id == id)
               .ProjectTo<ProductResponseDto>(_mapper.ConfigurationProvider)
               .FirstAsync();
        }
    }
}
