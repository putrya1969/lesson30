using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public DateTime OrderData { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
