namespace SolidProducts.Entities
{
    public class Client : BaseEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int DocumentNumber { get; set; }
        public required int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}