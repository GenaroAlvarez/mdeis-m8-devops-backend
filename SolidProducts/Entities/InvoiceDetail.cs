namespace SolidProducts.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; } // monto calculado de descuento el descuento es por producto
        public decimal Subtotal { get; set; } // subtotal = cantidad * precio - descuento
        public int InvoiceId { get; set; }
        public virtual required Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public virtual required Product Product { get; set; }
        public required int WarehouseId { get; set; }
        public required virtual Warehouse Warehouse { get; set; }
    }
}