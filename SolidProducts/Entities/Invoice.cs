
namespace SolidProducts.Entities
{
    public class Invoice : BaseEntity
    {
        public required decimal Total { get; set; }
        public required decimal Nit { get; set; }
        public required string BusinessName { get; set; }
        public int ClientId { get; set; }
        public required int PaymentConditionId { get; set; }
        public required virtual Client Client { get; set; }
        public required virtual PaymentCondition PaymentCondition { get; set; }
        public virtual ICollection<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();
    }
}