static string? GetOptionalCustomerName(int id)
{
  return id switch
  {
    1 => "Alice",
    2 => null,
    _ => "Unknown Customer"
  };
}

static void PrintCustomerName(string? name)
{
  if (string.IsNullOrWhiteSpace(name))
  {
    Console.WriteLine("No customer name was supplied.");
    return;
  }

  Console.WriteLine($"Customer name length: {name.Length}");
}

static void PrintRequiredName(string name)
{
  ArgumentNullException.ThrowIfNull(name);
  Console.WriteLine($"Required name: {name}");
}

string firstName = "Alice";
string? middleName = null;

Console.WriteLine(firstName.ToUpper());

if (middleName is not null)
{
  Console.WriteLine(middleName.ToUpper());
}
else
{
  Console.WriteLine("No middle name.");
}

string? customerName = GetOptionalCustomerName(2);
PrintCustomerName(customerName);

var customer = new Customer(
  "Contoso Ltd",
  new Address("London"));

if (customer is { Address: not null })
{
  Console.WriteLine(customer.Address.City);
}

string? configuredName = "Configured Customer";
Console.WriteLine(configuredName!.Length);

PrintRequiredName("Mark");

public record Address(string City);
public record Customer(string Name, Address? Address);
