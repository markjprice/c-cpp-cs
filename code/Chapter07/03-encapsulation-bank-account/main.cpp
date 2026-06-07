#include <iostream>

class BankAccount
{
private:
  double balance = 0.0;

public:
  explicit BankAccount(double initialBalance)
  {
    if (initialBalance >= 0.0)
    {
      balance = initialBalance;
    }
  }

  void deposit(double amount)
  {
    if (amount > 0.0)
    {
      balance += amount;
    }
  }

  bool withdraw(double amount)
  {
    if (amount > 0.0 && amount <= balance)
    {
      balance -= amount;
      return true;
    }

    return false;
  }

  double getBalance() const
  {
    return balance;
  }
};

int main()
{
  BankAccount account(100.0);

  account.deposit(50.0);

  if (!account.withdraw(200.0))
  {
    std::cout << "Withdrawal rejected.\n";
  }

  if (account.withdraw(75.0))
  {
    std::cout << "Withdrawal accepted.\n";
  }

  std::cout << "Final balance: " << account.getBalance() << "\n";

  return 0;
}
