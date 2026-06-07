#include <iostream>
#include <memory>
#include <vector>

class Task
{
private:
  int id;

public:
  explicit Task(int taskId) : id(taskId)
  {
    std::cout << "Task " << id << " created\n";
  }

  ~Task()
  {
    std::cout << "Task " << id << " destroyed\n";
  }

  void run() const
  {
    std::cout << "Running task " << id << "\n";
  }
};

int main()
{
  std::vector<std::unique_ptr<Task>> tasks;
  tasks.push_back(std::make_unique<Task>(1));
  tasks.push_back(std::make_unique<Task>(2));
  tasks.push_back(std::make_unique<Task>(3));

  for (const auto& task : tasks)
  {
    task->run();
  }

  std::cout << "Leaving main. The vector and its unique_ptr elements clean up automatically.\n";
}
