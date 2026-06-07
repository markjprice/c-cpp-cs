#include "Account.hpp"
#include "Bank.hpp"
#include "SavingsAccount.hpp"

#include <memory>

int main()
{
  Bank bank;

  bank.addAccount(std::make_unique<Account>(500));
  bank.addAccount(std::make_unique<SavingsAccount>(1000, 0.05));

  bank.process();

  return 0;
}
