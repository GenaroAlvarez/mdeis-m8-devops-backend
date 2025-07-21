
namespace SolidProducts.Entities
{
    public class ClientGroup : BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public decimal? Discount { get; set; }
        public ICollection<Client> Clients { get; } = [];
    }
}