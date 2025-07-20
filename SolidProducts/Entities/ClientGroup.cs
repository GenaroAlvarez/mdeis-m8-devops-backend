
namespace SolidProducts.Entities
{
    public class ClientGroup : BaseEntity
    {
        public required string Name { get; set; }
        public decimal? Discount { get; set; }
    }
}