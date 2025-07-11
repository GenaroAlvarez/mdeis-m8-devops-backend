namespace SolidProducts.DTOs
{
    public class ProductRequestDto
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string ManufacturerSku { get; set; }
        public int ProductGroupId { get; set; }
        public int ManufacturerId { get; set; }
        public int SupplierId { get; set; }
        public decimal Weight { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public string AlternateSku { get; set; }
    }
}
