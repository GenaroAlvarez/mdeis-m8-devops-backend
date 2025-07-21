using SolidProducts.DTOs;

namespace SolidProducts.Util;

public static class Calculations
{
    public static ProductCalculationResponseDto CalculationProduct(ClientResponseDto clientResponseDto, ProductResponseDto productResponseDto, int quantity)
    {
        decimal discountTotal =
            (clientResponseDto.ClientGroup.Discount ?? 0) +
            (productResponseDto.ProductGroup.Discount ?? 0);

        var discountResponse = CalculationDiscountAmount(productResponseDto.Price, quantity, discountTotal);

        return new ProductCalculationResponseDto
        {
            Product = productResponseDto,
            Quantity = quantity,
            DiscountPercentage = discountTotal,
            Discount = discountResponse.DiscountAmount,
            Subtotal = discountResponse.Subtotal,
        };
    }

    public static DiscountResponseDto CalculationDiscountAmount(decimal unitPrice, int quantity, decimal discountValue)
    {
        if (quantity <= 0 || unitPrice < 0 || discountValue < 0)
            throw new ArgumentException("Los valores ingresados no son válidos.");

        decimal discountPerUnit = unitPrice * (discountValue / 100m);

        decimal finalUnitPrice = unitPrice - discountPerUnit;

        return new DiscountResponseDto
        {
            DiscountAmount = discountPerUnit * quantity,
            Subtotal = finalUnitPrice * quantity
        };
    }
}
