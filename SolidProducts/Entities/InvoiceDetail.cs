using System.Text.Json.Serialization;

namespace SolidProducts.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; } // monto calculado de descuento el descuento es por producto
        public decimal Subtotal { get; set; } // subtotal = cantidad * precio - descuento
        public int InvoiceId { get; set; }

        [JsonIgnore]
        public virtual Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public required int WarehouseId { get; set; }
        public required Warehouse Warehouse { get; set; }
    }
}