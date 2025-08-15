namespace SolidProducts.DTOs;

public class ProductCalculationResponseDto
{
    public required ProductResponseDto Product {  get; set; }
    public int Quantity {  get; set; }
    public decimal DiscountPercentage {  get; set; }
    public decimal Discount { get; set; }
    public decimal Subtotal { get; set; }
}
