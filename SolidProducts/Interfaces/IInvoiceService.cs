using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Interfaces;

public interface IInvoiceService
{
       Task<Invoice> CreateAsync(InvoiceRequestDto request);
    
}
