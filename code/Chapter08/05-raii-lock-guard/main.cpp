#include <iostream>
#include <mutex>

std::mutex gate;
int sharedCounter = 0;

class SimpleLockGuard
{
private:
  std::mutex& mutex;

public:
  explicit SimpleLockGuard(std::mutex& m) : mutex(m)
  {
    mutex.lock();
    std::cout << "Locked\n";
  }

  ~SimpleLockGuard()
  {
    mutex.unlock();
    std::cout << "Unlocked\n";
  }

  SimpleLockGuard(const SimpleLockGuard&) = delete;
  SimpleLockGuard& operator=(const SimpleLockGuard&) = delete;
};

void updateCounter()
{
  SimpleLockGuard guard(gate);
  ++sharedCounter;
  std::cout << "Counter is now " << sharedCounter << "\n";
}

int main()
{
  updateCounter();
  updateCounter();
  std::cout << "std::lock_guard provides this pattern in the standard library.\n";
}
