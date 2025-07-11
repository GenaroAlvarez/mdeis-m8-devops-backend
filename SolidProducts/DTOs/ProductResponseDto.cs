namespace SolidProducts.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string ManufacturerSku { get; set; }
        public string ProductGroupName { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
        public decimal Weight { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public string AlternateSku { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
