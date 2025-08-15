using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_SolidProducts.Models
{
    internal class Client
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int ClientGroupId { get; set; }
    }
}
