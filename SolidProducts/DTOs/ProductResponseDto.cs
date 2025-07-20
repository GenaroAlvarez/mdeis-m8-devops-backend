using SolidProducts.Entities;

namespace SolidProducts.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required ProductGroup ProductGroup { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
