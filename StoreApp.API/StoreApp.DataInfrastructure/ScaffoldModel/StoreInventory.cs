using System;
using System.Collections.Generic;

namespace StoreApp.DataInfrastructure
{
    public partial class StoreInventory
    {
        public int LocationId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int ProductAmount { get; set; }

        public virtual Location Location { get; set; } = null!;
    }
}
