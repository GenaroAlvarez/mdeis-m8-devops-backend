using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;
public interface IDocumentTypeService
{
    Task<IEnumerable<DocumentTypeResponseDto>> GetAllAsync();
}