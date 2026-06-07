#include "SavingsAccount.hpp"

#include <iostream>

SavingsAccount::SavingsAccount(double initial, double rate)
  : Account(initial), interestRate(rate)
{
}

void SavingsAccount::applyInterest()
{
  balance += balance * interestRate;
}

void SavingsAccount::print() const
{
  std::cout << "Savings Account - Balance: " << balance << "\n";
}
