#include <iostream>

namespace User
{
  void print()
  {
    std::cout << "Printing a user\n";
  }
}

namespace Invoice
{
  void print()
  {
    std::cout << "Printing an invoice\n";
  }
}

namespace Networking
{
  void connect()
  {
    std::cout << "Connecting to the network\n";
  }
}

namespace Database
{
  void connect()
  {
    std::cout << "Connecting to the database\n";
  }
}

int main()
{
  User::print();
  Invoice::print();
  Networking::connect();
  Database::connect();
}
