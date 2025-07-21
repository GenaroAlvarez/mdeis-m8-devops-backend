using SolidProducts.Entities;

namespace SolidProducts.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required string Brand { get; set; }
        public required ProductGroup ProductGroup { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
