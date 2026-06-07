#include "Account.hpp"

#include <iostream>

Account::Account(double initial)
  : balance(initial >= 0.0 ? initial : 0.0)
{
}

void Account::deposit(double amount)
{
  if (amount > 0.0)
  {
    balance += amount;
  }
}

bool Account::withdraw(double amount)
{
  if (amount > 0.0 && amount <= balance)
  {
    balance -= amount;
    return true;
  }

  return false;
}

void Account::print() const
{
  std::cout << "Account - Balance: " << balance << "\n";
}
