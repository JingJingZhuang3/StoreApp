using System;
using System.Collections.Generic;

namespace StoreApp.DataInfrastructure
{
    public partial class OrderProduct
    {
        public int OrderNum { get; set; }
        public string ProductName { get; set; } = null!;
        public int Amount { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset OrderTime { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual CustomerOrder OrderNumNavigation { get; set; } = null!;
    }
}
