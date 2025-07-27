namespace SolidProducts.DTOs;

public class InvoiceResponseDto
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public ClientResponseDto Client { get; set; }
    public PaymentConditionResponseDto PaymentCondition { get; set; }
    public List<InvoiceDetailResponse> InvoiceDetails { get; set; }
}

public class InvoiceDetailResponse
{
    public int Id { get; set; }
    public ProductResponseDto Product { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}