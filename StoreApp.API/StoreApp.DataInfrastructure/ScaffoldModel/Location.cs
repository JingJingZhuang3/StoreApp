using System;
using System.Collections.Generic;

namespace StoreApp.DataInfrastructure
{
    public partial class Location
    {
        public Location()
        {
            OrderProducts = new HashSet<OrderProduct>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int Id { get; set; }
        public string StoreLocation { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
