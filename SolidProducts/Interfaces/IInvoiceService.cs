using SolidProducts.DTOs;

namespace SolidProducts.Interfaces;

public interface IInvoiceService
{
       Task CreateAsync(InvoiceRequestDto request);
    
}
