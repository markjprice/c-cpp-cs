#pragma once

#include "Account.hpp"

class SavingsAccount : public Account
{
private:
  double interestRate;

public:
  SavingsAccount(double initial, double rate);
  void applyInterest();
  void print() const override;
};
