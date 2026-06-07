#include "user_manager.h"
#include "database_connection.h"

int main(void)
{
  user_manager_init();
  database_connection_init();

  database_connection_shutdown();
  user_manager_shutdown();

  return 0;
}
