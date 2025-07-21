namespace SolidProducts.Entities
{
    public class ProductGroup : BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public decimal? Discount { get; set; }
        public ICollection<Product> Products { get; } = [];
    }
}
