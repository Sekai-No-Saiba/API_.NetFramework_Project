using System;
using System.Threading.Tasks;

namespace TaskManagerTerminal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Exit");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task title: ");
                        var title = Console.ReadLine();
                        await taskManager.AddTask(title);
                        break;

                    case "2":
                        await taskManager.ListTasks();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
