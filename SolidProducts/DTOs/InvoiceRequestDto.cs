namespace SolidProducts.DTOs;

public class InvoiceRequestDto
{
    public required int Nit { get; set; }
    public required string BusinessName { get; set; } = string.Empty;
    public required decimal Total { get; set; }
    public required ClientRequest Client { get; set; }
    public required IEnumerable<InvoiceDetailRequest> InvoiceDetails { get; set; }
    public required PaymentConditionRequest PaymentCondition { get; set; }
}

public class ClientRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}

public class InvoiceDetailRequest
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal Subtotal { get; set; }
    public required ProductRequest Product { get; set; }
    public int Warehouse { get; set; }
}

public class PaymentConditionRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}

public class ProductRequest
{
    public required int Id { get; set; }
}