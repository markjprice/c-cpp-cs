List<Employee> employees =
[
  new("Alice", "Engineering", 90000M),
  new("Bob", "Sales", 65000M),
  new("Charlie", "Engineering", 95000M),
  new("Diana", "Support", 55000M)
];

var grouped = employees.GroupBy(employee => employee.Department);

foreach (var group in grouped)
{
  decimal average = group.Average(employee => employee.Salary);
  Console.WriteLine($"{group.Key}: {group.Count()} employees, average {average:C}");
}

List<Customer> customers = [new(1, "Northwind"), new(2, "Contoso")];
List<Order> orders = [new(101, 1, 150M), new(102, 1, 90M), new(103, 2, 200M)];

var joined = customers.Join(
  orders,
  customer => customer.Id,
  order => order.CustomerId,
  (customer, order) => new { customer.Name, order.OrderId, order.Total });

foreach (var item in joined)
{
  Console.WriteLine($"{item.Name} order {item.OrderId}: {item.Total:C}");
}

var customerOrders = customers.SelectMany(
  customer => orders.Where(order => order.CustomerId == customer.Id),
  (customer, order) => new { customer.Name, order.Total });

decimal totalSales = customerOrders.Sum(item => item.Total);
Console.WriteLine($"Total sales: {totalSales:C}");

public record Employee(string Name, string Department, decimal Salary);
public record Customer(int Id, string Name);
public record Order(int OrderId, int CustomerId, decimal Total);
