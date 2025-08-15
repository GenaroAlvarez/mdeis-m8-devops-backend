namespace SolidProducts.DTOs;

public class InvoiceRequestDto
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public int ClientId { get; set; }
    // public ClientResponseDto Client { get; set; }
    public int PaymentConditionId { get; set; }
    //  public PaymentConditionResponseDto PaymentCondition { get; set; }
    public List<InvoiceDetailRequest> InvoiceDetails { get; set; }
}

public class InvoiceDetailRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    // public ProductResponseDto Product { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}