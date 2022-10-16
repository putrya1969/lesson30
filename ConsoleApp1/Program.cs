using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            using (EFlessonDBContext context = new EFlessonDBContext())
            {

                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                //var employees = context.Employees;
                //foreach (var item in employees)
                //{
                //    Console.WriteLine($"EmployeeId:{item.Id} Employee name:{ item.EmployeeName}");
                //}

                GenerateOrder(context);
                ShowOrders(context);
            }
        }

        static void GenerateOrder(EFlessonDBContext context)
        {
            var employee = GetEmployee(context.Employees);
            var customer = GetCustomer(context.Customers);
            var products = context.Products.ToList();
            var order = new Order();
            order.CustomerId = customer.Id;
            order.EmployeeId = employee.Id;
            order.OrderData = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();
            var numberProducts = random.Next(1, 4);
            for (int i = 0; i < numberProducts; i++)
            {
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.ProductId = GetProduct(context.Products).Id;
                orderProduct.OrderId = order.Id;
                orderProduct.ProductCount = random.Next(1, 4);
                context.OrderProducts.Add(orderProduct);
            }
            context.SaveChanges();

        }

        static Product? GetProduct(DbSet<Product> set)
        {
            var products = set.ToList();
            var upperBound = products.Count;
            var randomIndex = random.Next(1, upperBound);
            return products.Where(e => e.Id == randomIndex).FirstOrDefault();
        }
        static Customer? GetCustomer(DbSet<Customer> set)
        {
            var customers = set.ToList();
            var upperBound = customers.Count;
            var randomIndex = random.Next(1, upperBound);
            return customers.Where(e => e.Id == randomIndex).FirstOrDefault();
        }

        static Employee? GetEmployee(DbSet<Employee> set)
        {
            var employees = set.ToList();
            var upperBound = employees.Count;
            var randomIndex = random.Next(1, upperBound);
            return employees.Where(e => e.Id == randomIndex).FirstOrDefault();
        }

        static void ShowOrders(EFlessonDBContext context)
        {
            var report = from o in context.Orders
                         join op in context.OrderProducts on o.Id equals op.OrderId
                         join p in context.Products on op.ProductId equals p.Id
                         join c in context.Customers on o.CustomerId equals c.Id
                         join e in context.Employees on o.EmployeeId equals e.Id
                         select new
                         {
                             EmployeeName = e.EmployeeName,
                             CustomerName = c.CustomerName,
                             ProductName = p.ProductName,
                             ProductCount = op.ProductCount
                         };
            foreach (var item in report)
            {
                Console.WriteLine($"Employee: {item.EmployeeName} Customer: {item.CustomerName}\n\t" +
                    $"Product: {item.ProductName} Quantity: {item.ProductCount}");
            }

        }
    }
}