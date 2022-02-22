using System;
using System.Collections.Generic;

namespace StoreApp.DataInfrastructure
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
