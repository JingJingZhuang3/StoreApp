using System;
using System.Collections.Generic;

namespace StoreApp.DataInfrastructure
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderNum { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
