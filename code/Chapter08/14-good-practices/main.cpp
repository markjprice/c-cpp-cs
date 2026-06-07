#include <iostream>
#include <memory>
#include <string>
#include <vector>

class Report
{
private:
  std::string title;
  std::vector<int> values;

public:
  explicit Report(std::string t) : title(std::move(t)) {}

  void addValue(int value)
  {
    values.push_back(value);
  }

  void print() const
  {
    std::cout << title << "\n";
    for (int value : values)
    {
      std::cout << "  " << value << "\n";
    }
  }
};

std::unique_ptr<Report> createReport()
{
  auto report = std::make_unique<Report>("Memory-safe report");
  report->addValue(10);
  report->addValue(20);
  report->addValue(30);
  return report;
}

void printReport(const Report& report)
{
  report.print();
}

int main()
{
  auto report = createReport();
  printReport(*report);

  std::vector<std::unique_ptr<Report>> reports;
  reports.push_back(std::move(report));

  std::cout << "Reports owned by vector: " << reports.size() << "\n";
  std::cout << "All cleanup is automatic.\n";
}
