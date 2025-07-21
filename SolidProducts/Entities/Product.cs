namespace SolidProducts.Entities
{
    public class Product : BaseEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; } = null!;
    }
}