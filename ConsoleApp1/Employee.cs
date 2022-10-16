using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string EmployeeName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
