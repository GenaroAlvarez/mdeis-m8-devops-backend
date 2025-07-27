using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;
public class DocumentTypeService: IDocumentTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DocumentTypeService(IUnitOfWork uow, IMapper mapper)
    {
        _unitOfWork = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DocumentTypeResponseDto>> GetAllAsync()
    {
        return await _unitOfWork.DocumentTypes.Query()
            .ProjectTo<DocumentTypeResponseDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}