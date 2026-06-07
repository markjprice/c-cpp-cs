#pragma once

#include "Account.hpp"

#include <memory>
#include <vector>

class Bank
{
private:
  std::vector<std::unique_ptr<Account>> accounts;

public:
  void addAccount(std::unique_ptr<Account> acc);
  void process();
};
