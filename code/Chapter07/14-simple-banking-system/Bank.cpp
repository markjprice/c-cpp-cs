#include "Bank.hpp"

#include <utility>

void Bank::addAccount(std::unique_ptr<Account> acc)
{
  accounts.push_back(std::move(acc));
}

void Bank::process()
{
  for (auto& acc : accounts)
  {
    acc->deposit(100);
    acc->withdraw(50);
    acc->print();
  }
}
