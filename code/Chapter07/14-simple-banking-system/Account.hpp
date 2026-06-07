#pragma once

class Account
{
protected:
  double balance;

public:
  explicit Account(double initial);
  virtual void deposit(double amount);
  virtual bool withdraw(double amount);
  virtual void print() const;
  virtual ~Account() = default;
};
