using System.Collections.Generic;

namespace SolidProducts.Entities
{
    public class Client : BaseEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int ClientGroupId { get; set; }
        public required virtual ClientGroup ClientGroup { get; set; }
    }
}