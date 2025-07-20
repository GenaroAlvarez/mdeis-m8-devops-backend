namespace SolidProducts.Entities
{
    public class Product : BaseEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int ProductGroupId { get; set; }
        public required virtual ProductGroup ProductGroup { get; set; }
    }
}