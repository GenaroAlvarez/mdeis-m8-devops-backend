using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_SolidProducts.Models
{
    internal class InvoiceDetail
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
        public int WarehouseId { get; set; }
    }
}
