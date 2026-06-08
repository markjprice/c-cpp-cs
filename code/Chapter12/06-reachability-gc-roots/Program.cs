Report report = new() { Title = "Monthly sales" };
Console.WriteLine(report.Title);

ReportStore.Reports.Add(report);
report = null!;

Console.WriteLine($"Reports still stored: {ReportStore.Reports.Count}");
Console.WriteLine("The local reference was removed, but the static list still keeps the object reachable.");

Company company = new()
{
  Department = new Department
  {
    Manager = new Employee("Grace Hopper")
  }
};

Console.WriteLine(company.Department.Manager.Name);
Console.WriteLine("If company is reachable, the department and manager are reachable through the object graph.");

public static class ReportStore
{
  public static List<Report> Reports { get; } = new();
}

public sealed class Report
{
  public string Title { get; set; } = "";
}

public sealed class Company
{
  public Department Department { get; set; } = new();
}

public sealed class Department
{
  public Employee Manager { get; set; } = new("Unknown");
}

public sealed record Employee(string Name);
