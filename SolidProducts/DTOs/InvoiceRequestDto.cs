using SolidProducts.Entities;

namespace SolidProducts.DTOs;

public class InvoiceRequestDto
{
    public required int Nit { get; set; }
    public required string BusinessName { get; set; } = string.Empty;
    public required decimal Total { get; set; }
}
