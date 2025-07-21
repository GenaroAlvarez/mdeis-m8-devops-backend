namespace SolidProducts.Entities
{
    public class Client : BaseEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int ClientGroupId { get; set; }
        public ClientGroup ClientGroup { get; set; } = null!;
    }
}