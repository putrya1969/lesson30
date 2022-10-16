using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
