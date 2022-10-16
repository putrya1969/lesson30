using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public double? Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
