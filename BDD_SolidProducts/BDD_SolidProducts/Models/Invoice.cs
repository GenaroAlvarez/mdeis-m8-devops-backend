using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_SolidProducts.Models
{
    internal class Invoice
    {
        public decimal Nit { get; set; }
        public string BusinessName { get; set; } = null!;
        public int ClientId { get; set; }
        public int PaymentConditionId { get; set; }
        public decimal Total { get; set; }
        public List<InvoiceDetail> Details { get; set; } = new();
    }
}
