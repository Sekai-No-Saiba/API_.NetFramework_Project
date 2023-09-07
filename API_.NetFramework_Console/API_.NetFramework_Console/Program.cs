using API_.NetFramework_Project.Models;
using System;
using System.Threading.Tasks;

namespace TaskManagerTerminal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var taskManager = new TaskManager(new System.Net.Http.HttpClient());

            while (true)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. List Completed Tasks");
                Console.WriteLine("6. List Incomplete Tasks");
                Console.WriteLine("7. Exit");

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
                        Console.Write("Enter task ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out var taskId))
                        {
                            Console.Write("Enter updated task title: ");
                            var updatedTitle = Console.ReadLine();
                            Console.Write("Is the task completed? (true/false): ");
                            if (bool.TryParse(Console.ReadLine(), out var isCompleted))
                            {
                                var updatedTask = new TaskTp
                                {
                                    Title = updatedTitle,
                                    IsCompleted = isCompleted
                                };
                                await taskManager.UpdateTask(taskId, updatedTask);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for 'Is the task completed?'");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for 'Enter task ID to update.'");
                        }
                        break;

                    case "4":
                        Console.Write("Enter task ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out var deleteTaskId))
                        {
                            await taskManager.DeleteTask(deleteTaskId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for 'Enter task ID to delete.'");
                        }
                        break;

                    case "5":
                        await taskManager.ListCompletedTasks();
                        break;

                    case "6":
                        await taskManager.ListIncompleteTasks();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}





//using API_.NetFramework_Project.Models;
//using System;
//using System.Threading.Tasks;

//namespace TaskManagerTerminal
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            var taskManager = new TaskManager(new System.Net.Http.HttpClient());

//            while (true)
//            {
//                Console.WriteLine("1. Add Task");
//                Console.WriteLine("2. List Tasks");
//                Console.WriteLine("3. Update Task");
//                Console.WriteLine("4. Delete Task");
//                Console.WriteLine("5. Exit");

//                Console.Write("Select an option: ");
//                var choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.Write("Enter task title: ");
//                        var title = Console.ReadLine();
//                        await taskManager.AddTask(title);
//                        break;

//                    case "2":
//                        await taskManager.ListTasks();
//                        break;

//                    case "3":
//                        Console.Write("Enter task ID to update: ");
//                        if (int.TryParse(Console.ReadLine(), out var taskId))
//                        {
//                            Console.Write("Enter updated task title: ");
//                            var updatedTitle = Console.ReadLine();
//                            Console.Write("Is the task completed? (true/false): ");
//                            if (bool.TryParse(Console.ReadLine(), out var isCompleted))
//                            {
//                                var updatedTask = new TaskTp
//                                {
//                                    Title = updatedTitle,
//                                    IsCompleted = isCompleted
//                                };
//                                await taskManager.UpdateTask(taskId, updatedTask);
//                            }
//                            else
//                            {
//                                Console.WriteLine("Invalid input for 'Is the task completed?'");
//                            }
//                        }
//                        else
//                        {
//                            Console.WriteLine("Invalid input for 'Enter task ID to update.'");
//                        }
//                        break;

//                    case "4":
//                        Console.Write("Enter task ID to delete: ");
//                        if (int.TryParse(Console.ReadLine(), out var deleteTaskId))
//                        {
//                            await taskManager.DeleteTask(deleteTaskId);
//                        }
//                        else
//                        {
//                            Console.WriteLine("Invalid input for 'Enter task ID to delete.'");
//                        }
//                        break;

//                    case "5":
//                        return;

//                    default:
//                        Console.WriteLine("Invalid choice. Try again.");
//                        break;
//                }
//            }
//        }
//    }
//}






//using System;
//using System.Threading.Tasks;

//namespace TaskManagerTerminal
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            var taskManager = new TaskManager();

//            while (true)
//            {
//                Console.WriteLine("1. Add Task");
//                Console.WriteLine("2. List Tasks");

//                Console.WriteLine("3. Exit");


//                Console.Write("Select an option: ");
//                var choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.Write("Enter task title: ");
//                        var title = Console.ReadLine();
//                        await taskManager.AddTask(title);
//                        break;

//                    case "2":
//                        await taskManager.ListTasks();
//                        break;

//                    case "3":
//                        return;

//                    default:
//                        Console.WriteLine("Invalid choice. Try again.");
//                        break;
//                }
//            }
//        }
//    }
//}
